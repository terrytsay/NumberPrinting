using System;
using System.Collections.Generic;

namespace NumberPrinting.Tests
{
    class MockTextPrinter : ITextPrinter
    {
        public List<string> TextsPrinted { get; set; }

        public MockTextPrinter()
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
}