using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayStationsClosers.Output
{
    public class FileOutputWriter : IOutputWriter
    {
        private readonly FileInfo _outputFile;
        private const string FilePostfix = "_out";
        public FileOutputWriter(string originlFileName)
        {
            if(string.IsNullOrWhiteSpace(originlFileName))
            {
                throw new TypeInitializationException("FileOutputWriter", new Exception("Empty original file name."));
            }
            var originFile = new FileInfo(originlFileName);
            string outputFileName = originFile.FullName.TrimEnd(originFile.Extension.ToCharArray()) + FilePostfix + originFile.Extension;
            _outputFile = new FileInfo(outputFileName);
        }

        public void Write(IEnumerable<int> data)
        {
            if(_outputFile.Exists)
            {
                _outputFile.Delete();               
            }
            
            using (StreamWriter sr = _outputFile.CreateText())
            {
                foreach(var line in data)
                {
                    sr.WriteLine(line);
                }
            }
        }
    }
}
