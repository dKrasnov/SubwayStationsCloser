using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayStationsClosers.Input
{
    public class FileInputDataReader : IInputDataReader
    {
        private readonly string _filePath;
        public FileInputDataReader(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new TypeInitializationException("FileInputDataReader", new NullReferenceException("filePath can not be null"));
            }

            if (!File.Exists(filePath))
            {
                throw new TypeInitializationException("FileInputDataReader", new FileNotFoundException("Not found {0}. Check the file path.", filePath));
            }

            _filePath = filePath;
        }
        public string GetInitString()
        {
            string initStr = null;
            foreach (var initLine in File.ReadLines(_filePath))
            {
                if (string.IsNullOrWhiteSpace(initLine))
                {
                    throw new Exception("Empty first line. First line must contains N and M values.");
                }

                initStr = initLine;

                break;
            }
            return initStr;
        }

        public IEnumerable<string> GetRelaitonsInfo()
        {
            bool firstLine = false;
            foreach (var line in File.ReadLines(_filePath))
            {
                //Used for init data
                if (!firstLine)
                {
                    firstLine = true;
                    continue;
                }

                yield return line;
            }
        }
    }
}
