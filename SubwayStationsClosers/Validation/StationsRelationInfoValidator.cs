using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayStationsClosers.Validation
{
	public class StationsRelationInfoValidator : IStationsRelationInfoValidator
	{
		public ValidationResultModel Validate(int stationsTotalCont, int station1, int station2)
		{
			if (stationsTotalCont <= 0)
			{
				throw new ArgumentException("Station total count can not be zero or less.");
			}

			var result = new ValidationResultModel { IsValid = true };

			if (station1 < 0 || station2 < 0)
			{
				result.IsValid = false;
				result.ErrorMessage = "Station number can not be less than zero.";
			}

			if (station1 >= stationsTotalCont || station2 >= stationsTotalCont)
			{
				result.IsValid = false;
				result.ErrorMessage = "Station number can not be greater or equal N.";
			}

			return result;
		}
	}
}
