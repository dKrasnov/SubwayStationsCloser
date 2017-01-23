using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubwayStationsClosers.Validation;

namespace UnitTests
{
    [TestClass]
    public class StationsRelationInfoValidatorTests
    {
        [TestMethod]
        public void Validate_StationIndexGTETotalCountTest()
        {
            var validator = new StationsRelationInfoValidator();
            var model = validator.Validate(10, 11, 10);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void Validate_StationIndexLessThanTotalCountTest()
        {
            var validator = new StationsRelationInfoValidator();
            var model = validator.Validate(10, 9, 9);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void Validate_StationIndexLessThanZeroTest()
        {
            var validator = new StationsRelationInfoValidator();
            var model = validator.Validate(10, -1, 9);
            Assert.IsFalse(model.IsValid);
        }
    }
}
