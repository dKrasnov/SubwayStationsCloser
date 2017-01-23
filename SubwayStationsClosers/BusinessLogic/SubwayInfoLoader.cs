using SubwayStationsClosers.BusinessLogic.Models;
using SubwayStationsClosers.Input;
using SubwayStationsClosers.Parser;
using SubwayStationsClosers.Validation;
using System;
using System.Collections.Generic;

namespace SubwayStationsClosers.BusinessLogic
{
    public class SubwayInfoLoader : ISubwayInfoLoader
    {
        private readonly IInputDataReader _dataReader;
        private readonly IInputDataParser _parser;
        private readonly IStationsRelationInfoValidator _relationsValidator;

        public SubwayInfoLoader(IInputDataReader dataReader, IInputDataParser parser, IStationsRelationInfoValidator relationsValidator)
        {
            _dataReader = dataReader;
            _parser = parser;
            _relationsValidator = relationsValidator;
        }

        public SubwayInfo GetInfo()
        {
            SubwayInfo resultInfo = InitSubwayInfo();
            var processInfo = FillRelationsInfo(resultInfo);

            if (processInfo.SavedStationsCount < resultInfo.StationsTotalCount)
            {
                throw new Exception(string.Format("Inpud data contains less stations than was set in N param. N = {0} but saved {1} stations.", resultInfo.StationsTotalCount, processInfo.SavedStationsCount));
            }

            if (processInfo.SavedRelationsCount < resultInfo.RelationsTotalCount)
            {
                throw new Exception(string.Format("Inpud data contains less stations relations than was set in M param. M = {0} but saved {1} stations.", resultInfo.StationsTotalCount, processInfo.SavedStationsCount));
            }

            return resultInfo;
        }

        private SubwayInfo InitSubwayInfo()
        {
            int n = 0, m = 0;
            var initInfo = _dataReader.GetInitString();
            _parser.ParseInitData(initInfo, out n, out m);
            return new SubwayInfo(n, m);
        }

        private SubwayInfoFillingResult FillRelationsInfo(SubwayInfo info)
        {
            int savedStationsCount = 0;
            int savedRelationsCount = 0;
            try
            {
                foreach (var relationInfo in _dataReader.GetRelaitonsInfo())
                {

                    int station1 = 0, station2 = 0;
                    _parser.ParseRelationData(relationInfo, out station1, out station2);
                    int s1Index = GetIndex(station1);
                    int s2Index = GetIndex(station2);
                    var validateResult = _relationsValidator.Validate(info.StationsTotalCount, s1Index, s2Index);
                    if (!validateResult.IsValid)
                    {
                        throw new Exception(validateResult.ErrorMessage);
                    }

                    if (info.AdjacentStationsIndex[s1Index] == null)
                    {
                        info.AdjacentStationsIndex[s1Index] = new List<int>();
                        savedStationsCount++;
                    }

                    if (info.AdjacentStationsIndex[s2Index] == null)
                    {
                        info.AdjacentStationsIndex[s2Index] = new List<int>();
                        savedStationsCount++;
                    }

                    if (!info.AdjacentStationsIndex[s1Index].Contains(s2Index))
                    {
                        info.AdjacentStationsIndex[s1Index].Add(s2Index);
                        savedRelationsCount++;
                    }

                    if (!info.AdjacentStationsIndex[s2Index].Contains(s1Index))
                    {
                        info.AdjacentStationsIndex[s2Index].Add(s1Index);
                    }
                }

                return new SubwayInfoFillingResult() { SavedStationsCount = savedStationsCount, SavedRelationsCount = savedRelationsCount };
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("FillRelationsInfo failed after adding {0} infos abdout stations relations", savedRelationsCount), e);
            }
        }

        public static int GetIndex(int s)
        {
            return s - 1;
        }
    }
}
