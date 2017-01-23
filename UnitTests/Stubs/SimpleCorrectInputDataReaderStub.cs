using SubwayStationsClosers.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Stubs
{
    public class SimpleCorrectInputDataReaderStub : IInputDataReader
    {
        public const int N = 6;
        public const int M = 4;

        public string GetInitString()
        {
            return "6 4";
        }

        public IEnumerable<string> GetRelaitonsInfo()
        {
            return new string[]
            {
                "1 2",
                "2 3",
                "3 4",
                "4 5",
                "5 6"
            };
        }
    }
}
