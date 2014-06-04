using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberPrinting.Tests
{
    class DemoTextPrinter : ITextPrinter
    {
        public List<string> TextsPrinted { get; set; }

        public DemoTextPrinter()
        {
            TextsPrinted = new List<string>();
        }
        public void Write(string text)
        {
            TextsPrinted.Add(text);
        }

        public void WriteLine()
        {
            TextsPrinted.Add(Environment.NewLine);
        }
    }

    class DivisibleBy3PrintFizz : INumberHandler
    {
        public ExecutionResult Handle(int number)
        {
            if(number % 3 == 0)
                return new ExecutionResult("Fizz");
            return ExecutionResult.NotHandled;
        }
    }
    class DivisibleBy5PrintBuzz : INumberHandler
    {
        public ExecutionResult Handle(int number)
        {
            if (number % 5 == 0)
                return new ExecutionResult("Buzz");
            return ExecutionResult.NotHandled;
        }
    }
    [TestClass]
    public class NumberPrinterTest
    {
        private DemoTextPrinter Printer { get; set; }
        private NumberPrinter Subject { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Printer = new DemoTextPrinter();
            Subject = new NumberPrinter(1, 100, Printer);
            Subject.AddHandler(new DivisibleBy3PrintFizz());
            Subject.AddHandler(new DivisibleBy5PrintBuzz());
        }

        [TestMethod]
        public void PrintFizzWhenDivisibleBy3()
        {
            var expected = "Fizz";

            Subject.Print(3);

            Assert.AreEqual(1, Printer.TextsPrinted.Count);
            Assert.AreEqual(expected, Printer.TextsPrinted[0]);
        }

        [TestMethod]
        public void PrintBuzzWhenDivisibleBy5()
        {
            var expected = "Buzz";

            Subject.Print(5);

            Assert.AreEqual(1, Printer.TextsPrinted.Count);
            Assert.AreEqual(expected, Printer.TextsPrinted[0]);
        }

        [TestMethod]
        public void PrintFizzBuzzWhenDivisibleByBoth3And5()
        {
            Subject.Print(15);

            var textsPrinted = Printer.TextsPrinted;
            Assert.AreEqual(2, textsPrinted.Count);
            Assert.AreEqual("Fizz", textsPrinted[0]);
            Assert.AreEqual("Buzz", textsPrinted[1]);
        }

        [TestMethod]
        public void PrintTheNumberWhenNotDivisibleBy3Or5()
        {
            Subject.Print(1);

            var textsPrinted = Printer.TextsPrinted;
            Assert.AreEqual(1, textsPrinted.Count);
            Assert.AreEqual("1", textsPrinted[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionWhenNumberIsSmallerThan1()
        {
            Subject.Print(0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionWhenNumberIsGreaterThan100()
        {
            Subject.Print(101);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenPrinterIsNull()
        {
            new NumberPrinter(0, 1, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionWhenMinimumIsGreaterThanMaximum()
        {
            new NumberPrinter(1, 0, new DemoTextPrinter());
        }
    }
}

