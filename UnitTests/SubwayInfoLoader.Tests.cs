using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubwayStationsClosers.BusinessLogic;
using SubwayStationsClosers.Input;
using SubwayStationsClosers.Parser;
using SubwayStationsClosers.Validation;
using System;
using UnitTests.Stubs;

namespace UnitTests
{
    [TestClass]
    public class SubwayInfoLoaderTests
    {
        private readonly SimpleCorrectInputDataReaderStub _dataReaderStub;
        private readonly NotValidInputDataReaderStub _notValidDataReaderStub;
        public SubwayInfoLoaderTests()
        {
            _dataReaderStub = new SimpleCorrectInputDataReaderStub();
            _notValidDataReaderStub = new NotValidInputDataReaderStub();
        }


        [TestMethod]
        public void GetInfo_AdjacentStationsIndexLengthTest()
        {
            var parser = new InputDataParser();
            var relationsValidator = new StationsRelationInfoValidator();
            var infoLoader = new SubwayInfoLoader(_dataReaderStub, parser, relationsValidator);

            var result = infoLoader.GetInfo();

            Assert.AreEqual(result.AdjacentStationsIndex.Length, SimpleCorrectInputDataReaderStub.N);
        }

        [TestMethod]
        public void GetInfo_StationsTotalCountTest()
        {
            var parser = new InputDataParser();
            var relationsValidator = new StationsRelationInfoValidator();
            var infoLoader = new SubwayInfoLoader(_dataReaderStub, parser, relationsValidator);

            var result = infoLoader.GetInfo();

            Assert.AreEqual(result.StationsTotalCount, SimpleCorrectInputDataReaderStub.N);
        }

        [TestMethod]
        public void GetInfo_RelationsTotalCountTest()
        {
            var parser = new InputDataParser();
            var relationsValidator = new StationsRelationInfoValidator();
            var infoLoader = new SubwayInfoLoader(_dataReaderStub, parser, relationsValidator);

            var result = infoLoader.GetInfo();

            Assert.AreEqual(result.RelationsTotalCount, SimpleCorrectInputDataReaderStub.M);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "A loading of less count of relations than was set in init params was inappropriately allowed.")]
        public void GetInfo_LoadEmptyData()
        {
            var parser = new InputDataParser();
            var relationsValidator = new StationsRelationInfoValidator();
            var infoLoader = new SubwayInfoLoader(_notValidDataReaderStub, parser, relationsValidator);

            var result = infoLoader.GetInfo();
        }
    }
}
