using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayStationsClosers.Parser
{
    public class InputDataParser : IInputDataParser
    {
        public void ParseInitData(string data, out int stationsCount, out int relationsCount)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new FormatException("Can not parse init data. Data is empty.");
            }
            innerParseData(data, out stationsCount, out relationsCount);
        }

        public void ParseRelationData(string data, out int station1, out int station2)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new FormatException("Can not parse relation data. Data is empty.");
            }
            innerParseData(data, out station1, out station2);
        }

        private void innerParseData(string line, out int v1, out int v2)
        {
            var data = line.Split(' ');
            if (data.Length != 2)
            {
                throw new FormatException("Un expected line format. Expect two numbers splited by white space.");
            }
            int.TryParse(data[0], out v1);
            int.TryParse(data[1], out v2);
        }
    }
}
