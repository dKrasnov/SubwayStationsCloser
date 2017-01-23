using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubwayStationsClosers;
using SubwayStationsClosers.BusinessLogic;
using SubwayStationsClosers.Parser;
using SubwayStationsClosers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubwayStationsClosers.Input;
using UnitTests.Stubs;

namespace UnitTests
{
	[TestClass]
	public class CloseStationsServiceTests
	{
		private readonly IInputDataReader _simpleDataReader;
		private readonly IInputDataReader _dataReader;
		public CloseStationsServiceTests()
		{
			_simpleDataReader = new SimpleCorrectInputDataReaderStub();
			_dataReader = new CorrectInputDataReaderStub();
		}

		[TestMethod]
		public void GetClosedStations_SimpleDataCloseTest()
		{
			var parser = new InputDataParser();
			var relationsValidator = new StationsRelationInfoValidator();
			var dataLoader = new SubwayInfoLoader(_simpleDataReader, parser, relationsValidator);

			var result = new CloseStationsService(dataLoader).GetClosedStations();

			Assert.IsTrue(result.SequenceEqual(new List<int>() { 1, 6, 5, 4, 3, 2 }));
		}

		[TestMethod]
		public void GetClosedStations_CloseTest()
		{
			var parser = new InputDataParser();
			var relationsValidator = new StationsRelationInfoValidator();
			var dataLoader = new SubwayInfoLoader(_dataReader, parser, relationsValidator);

			var result = new CloseStationsService(dataLoader).GetClosedStations();

			Assert.IsTrue(result.SequenceEqual(new List<int>() { 1, 2, 5, 4, 3 }));
		}
	}
}
