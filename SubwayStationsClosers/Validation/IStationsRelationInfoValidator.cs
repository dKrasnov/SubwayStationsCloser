using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayStationsClosers.Validation
{
    public interface IStationsRelationInfoValidator
    {
        ValidationResultModel Validate(int stationsCont, int station1, int station2);
    }
}
