using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayStationsClosers.Parser
{
    public interface IInputDataParser
    {
        void ParseInitData(string data, out int stationsCount, out int relationsCount);
        void ParseRelationData(string data, out int station1, out int station2);
    }
}
