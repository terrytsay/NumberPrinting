using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberPrinting.Tests
{
    [TestClass]
    public class NumberProcessorTest
    {
        private NumberProcessor Subject { get; set; }
        private const int Minimum = 1;
        private const int Maximum = 100;

        [TestInitialize]
        public void Initialize()
        {
            Subject = new NumberProcessor(Minimum, Maximum);
            Subject.AddHandler(new DivisibleBy3PrintFizz());
            Subject.AddHandler(new DivisibleBy5PrintBuzz());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionWhenNumberIsSmallerThanMinimum()
        {
            Subject.Process(0).ToList();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionWhenNumberIsGreaterThanMaximum()
        {
            Subject.Process(101).ToList();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionWhenMinimumIsGreaterThanMaximum()
        {
            Subject = new NumberProcessor(Maximum, Minimum);
        }
        [TestMethod]
        public void PrintFizzWhenDivisibleBy3()
        {
            var expected = "Fizz";

            var actual = Subject.Process(3).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(expected, actual[0]);
        }
        [TestMethod]
        public void PrintBuzzWhenDivisibleBy5()
        {
            var expected = "Buzz";

            var actual = Subject.Process(5).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(expected, actual[0]);
        }

        [TestMethod]
        public void PrintFizzBuzzWhenDivisibleByBoth3And5()
        {
            var actual = Subject.Process(15).ToList();

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("Fizz", actual[0]);
            Assert.AreEqual("Buzz", actual[1]);
        }


        [TestMethod]
        public void PrintTheNumberWhenNotDivisibleBy3Or5()
        {
            var actual = Subject.Process(1).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("1", actual[0]);
        }
    }
}
