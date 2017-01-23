using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubwayStationsClosers.Input;

namespace UnitTests.Stubs
{
	public class CorrectInputDataReaderStub : IInputDataReader
	{
		public const int N = 5;
		public const int M = 5;

		public string GetInitString()
		{
			return "5 5";
		}

		public IEnumerable<string> GetRelaitonsInfo()
		{
			return new string[]
            {
                "5 4",
                "3 1",
                "3 2",
                "3 4",
                "3 5"
            };
		}
	}
}
