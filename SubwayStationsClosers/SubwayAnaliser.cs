using SubwayStationsClosers.BusinessLogic;
using SubwayStationsClosers.Output;

namespace SubwayStationsCloser
{
    public class SubwayAnaliser
    {
        private readonly ICloseStationsService _closeService;
        private readonly IOutputWriter _outputService;
        public SubwayAnaliser(ICloseStationsService closeService, IOutputWriter outputService)
        {
            _closeService = closeService;
            _outputService = outputService;
        }

        public void Run()
        {
            _outputService.Write(_closeService.GetClosedStations());
        }
    }
}
