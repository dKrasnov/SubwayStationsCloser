using SubwayStationsClosers.BusinessLogic;
using System.Collections.Generic;

namespace SubwayStationsClosers
{
    public class CloseStationsService : ICloseStationsService
    {
        private readonly SubwayInfo _info;
        private readonly bool[] _currentStationPath;        
        private readonly List<int> _orderedClosedStations;
        public CloseStationsService(ISubwayInfoLoader dataLoader)
        {
            _info = dataLoader.GetInfo();
            _currentStationPath = new bool[_info.StationsTotalCount];
            _orderedClosedStations = new List<int>();
        }

        public List<int> GetClosedStations()
        {   
            for (int i = 0; i < _info.AdjacentStationsIndex.Length; i++)
            {
                if (_info.AdjacentStationsIndex[i] != null)
                {
                    if (!_currentStationPath[i])
                    {
                        if (_info.AdjacentStationsIndex[i].Count > 1)
                        {
                            GetNextStations(i);
                            _orderedClosedStations.Add(SubwayInfo.GetNameByIndex(i));
                        }
                        else
                        {
                            _currentStationPath[i] = true;
                            _orderedClosedStations.Add(SubwayInfo.GetNameByIndex(i));
                        }
                    }                   
                }
            }

            return _orderedClosedStations;
        }

        private void GetNextStations(int currentStation)
        {
            _currentStationPath[currentStation] = true;
            foreach (var stationIndex in _info.AdjacentStationsIndex[currentStation])
            {
                if (!_currentStationPath[stationIndex])
                {
                    _currentStationPath[stationIndex] = true;
                    GetNextStations(stationIndex);
                    _orderedClosedStations.Add(SubwayInfo.GetNameByIndex(stationIndex));
                }
            }
        }
    }
}
