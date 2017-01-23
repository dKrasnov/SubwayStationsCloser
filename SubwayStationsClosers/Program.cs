using SubwayStationsCloser;
using SubwayStationsClosers.BusinessLogic;
using SubwayStationsClosers.Input;
using SubwayStationsClosers.Output;
using SubwayStationsClosers.Parser;
using SubwayStationsClosers.Validation;
using System;
using System.IO;

namespace SubwayStationsClosers
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            ShowHelp();
            do
            {
                s = Console.ReadLine().Trim();
                switch(s)
                {
                    case "":
                    case "?":
                    case "help":
                    case "h": { ShowHelp(); break; }
                    case "e":
                    case "exit": break;
                    default:
                        {
                            if (!File.Exists(s))
                            {
                                Console.WriteLine("File was not found. Check that passed argument.");
                            }
                            else
                            {
                                try
                                {
                                    ProcessFile(s);
                                    Console.WriteLine("Done. Check input directory.");
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                            ShowHelp();
                            break;
                        }
                }
            } while (s != "e" && s != "exit");
        }

        private static void ProcessFile(string filePath)
        {
            IInputDataReader dataReader = new FileInputDataReader(filePath);
            IInputDataParser parser = new InputDataParser();
            IStationsRelationInfoValidator validator = new StationsRelationInfoValidator();
            ISubwayInfoLoader dataLoader = new SubwayInfoLoader(dataReader, parser, validator);
            ICloseStationsService closeService = new CloseStationsService(dataLoader);
            IOutputWriter resultWriter = new FileOutputWriter(filePath);

            new SubwayAnaliser(closeService, resultWriter).Run();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Enter file path:");
        }
    }
}
