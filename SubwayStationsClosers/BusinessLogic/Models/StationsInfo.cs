using System;
using System.Collections;
using System.Collections.Generic;

namespace SubwayStationsClosers
{
    public class SubwayInfo
    {
        public readonly int StationsTotalCount;
        public readonly int RelationsTotalCount;
        public readonly List<int>[] AdjacentStationsIndex;
        
        public SubwayInfo(int stationsTotalCount, int relationsTotalCount)
        {
            StationsTotalCount = stationsTotalCount;
            RelationsTotalCount = relationsTotalCount;
            AdjacentStationsIndex = new List<int>[StationsTotalCount];
        }

        public static int GetNameByIndex(int stationIndex)
        {
            return stationIndex + 1;
        }
    }

    public struct StationRelation
    {
        public int First;
        public int Second;
    }
}