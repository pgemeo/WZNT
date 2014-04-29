using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Services
    {
        [TestMethod]
        public void LOG_START_STARTED_NULL()
        {
            Services.Log.LOG_START();            
        }

        [TestMethod]
        public void GetCallingMethod_PassGarbage_EmptyString()
        {
            Services.Log.Warning("  ");
        }

        [TestMethod]
        public void Divide_Numbers_floatExpected()
        {
            float c = Services.Log.Divide(5, 5);
            Assert.AreEqual(c, 5 / 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Divide_PassZero_ExceptionExpected()
        {
            float c = Services.Log.Divide(5, 0);
            Assert.AreEqual(c, 5 / 5);
        }
    }
}
