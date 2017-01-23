using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubwayStationsClosers.Output;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class FileOutputWriterTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeInitializationException), "A empty origin file name was inappropriately allowed.")]
        public void TypeInitialization_EmptyOriginFileNameTest()
        {
            var writer = new FileOutputWriter("");
        }
    }
}
