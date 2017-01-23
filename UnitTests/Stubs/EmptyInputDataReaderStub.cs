using SubwayStationsClosers.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Stubs
{
    public class NotValidInputDataReaderStub : IInputDataReader
    {
        public string GetInitString()
        {
            return "2, 3";
        }

        public IEnumerable<string> GetRelaitonsInfo()
        {
            return new string[]
                {
                    "1, 2"
                };
        }
    }
}
