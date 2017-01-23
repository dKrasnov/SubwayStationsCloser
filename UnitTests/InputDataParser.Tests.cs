using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubwayStationsClosers.Parser;
using System;

namespace UnitTests
{
    [TestClass]
    public class InputDataParserTests
    {
        [TestMethod]
        public void ParseInitData_ParsValidInitDataTest()
        {
            var parser = new InputDataParser();
            string testInitString = "1 2";
            int n = 0;
            int m = 0;
            parser.ParseInitData(testInitString, out n, out m);

            Assert.AreEqual(n, 1);
            Assert.AreEqual(m, 2);
        }

        [TestMethod]
        public void ParseInitData_ParsValidRelationDataTest()
        {
            var parser = new InputDataParser();
            string testRelationString = "1 2";
            int s1 = 0;
            int s2 = 0;
            parser.ParseInitData(testRelationString, out s1, out s2);

            Assert.AreEqual(s1, 1);
            Assert.AreEqual(s2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseInitData_ParseLongeLineTest()
        {
            var parser = new InputDataParser();
            string testRelationString = "1 2 1";
            int s1 = 0;
            int s2 = 0;
            parser.ParseInitData(testRelationString, out s1, out s2);            
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseInitData_ParseShorteLineTest()
        {
            var parser = new InputDataParser();
            string testRelationString = "1";
            int s1 = 0;
            int s2 = 0;
            parser.ParseInitData(testRelationString, out s1, out s2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseInitData_ParseEmptyLineTest()
        {
            var parser = new InputDataParser();
            string testRelationString = "";
            int s1 = 0;
            int s2 = 0;
            parser.ParseInitData(testRelationString, out s1, out s2);
        }
    }
}
