using System;
using System.Collections.Generic;

namespace NumberPrinting
{
    public class NumberPrinter : INumberPrinter
    {
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        private readonly ITextPrinter _printer;
        private readonly List<INumberHandler> _handlers; 

        public NumberPrinter(int minimum, int maximum, ITextPrinter printer)
        {
            if (minimum > maximum)
                throw new ArgumentOutOfRangeException("minimum", "Minimum should be smaller than Maximum.");
            if(ReferenceEquals(printer, null))
                throw new ArgumentNullException("printer");

            Minimum = minimum;
            Maximum = maximum;

            _printer = printer;
            _handlers = new List<INumberHandler>();
        }

        public void AddHandler(INumberHandler handler)
        {
            _handlers.Add(handler);
        }

        public void Print(int number)
        {
            if (number < Minimum || number > Maximum)
            {
                const string format = "The input number should be between {0} to {1}.";
                throw new ArgumentOutOfRangeException(string.Format(format, Minimum, Maximum));
            }

            var texts = GetTextsToPrint(number);

            foreach (var text in texts)
            {
                _printer.Write(text);
            }
        }

        private IEnumerable<string> GetTextsToPrint(int number)
        {
            var isHandled = false;
            foreach (var handler in _handlers)
            {
                var result = handler.Handle(number);
                if (result.IsHandled)
                {
                    isHandled = true;
                    yield return result.Result;
                }
            }

            if(!isHandled)
                yield return number.ToString();
        }
    }
}