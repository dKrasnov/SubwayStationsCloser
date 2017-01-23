using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayStationsClosers.Validation
{
    public class ValidationResultModel
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
