using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberPrinting.Tests
{
    [TestClass]
    public class ExecutionResultTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowErrorIfResultIsNull()
        {
            var subject = new ExecutionResult(null);
        }

        [TestMethod]
        public void StoreConstructorResultInProperty()
        {
            var expected = "123";
            var subject = new ExecutionResult(expected);
            var actual = subject.Result;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsHandledShouldBeTrueWhenResultIsPopulated()
        {
            var result = "123";
            var subject = new ExecutionResult(result);
            Assert.IsTrue(subject.IsHandled);
        }
    }
}
