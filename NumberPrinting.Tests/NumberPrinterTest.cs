using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberPrinting.Tests
{
    [TestClass]
    public class NumberPrinterTest
    {
        private MockTextPrinter Printer { get; set; }
        private MockNumberProcessor Processor { get; set; }
        private NumberPrinter Subject { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Printer = new MockTextPrinter();
            Processor = new MockNumberProcessor();
            Subject = new NumberPrinter(Processor, Printer);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenPrinterIsNull()
        {
            new NumberPrinter(Processor, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenProcessorIsNull()
        {
            new NumberPrinter(null, Printer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionWhenStartIsBiggerThanEnd()
        {
            Subject.Print(1, 0);
        }

        [TestMethod]
        public void WriteResultFromProcessForEachNumberInRange()
        {
            var expected = BuildExpectedOutput("1", "2").ToList();
            Processor.Setup(1, "1");
            Processor.Setup(2, "2");

            Subject.Print(1, 2);

            CollectionAssert.AreEqual(expected, Printer.TextsPrinted);
        }

        private IEnumerable<string> BuildExpectedOutput(params string[] results)
        {
            foreach (var result in results)
            {
                yield return result;
                yield return Environment.NewLine;
            }
        }
    }
}

