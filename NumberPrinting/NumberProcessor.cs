using System;
using System.Collections.Generic;

namespace NumberPrinting
{
    public class NumberProcessor : INumberProcessor
    {
        private readonly List<INumberHandler> _handlers; 

        public int Minimum { get; private set; }
        public int Maximum { get; private set; }
        public NumberProcessor(int minimum, int maximum)
        {
            if (minimum > maximum)
                throw new ArgumentOutOfRangeException("minimum", "Minimum should be smaller than Maximum.");
            
            Minimum = minimum;
            Maximum = maximum;

            _handlers = new List<INumberHandler>();
        }
        public void AddHandler(INumberHandler handler)
        {
            _handlers.Add(handler);
        }
        public IEnumerable<string> Process(int number)
        {
            if (number < Minimum || number > Maximum)
            {
                const string format = "The input number should be between {0} to {1}.";
                throw new ArgumentOutOfRangeException(string.Format(format, Minimum, Maximum));
            }

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

            if (!isHandled)
                yield return number.ToString();
        }
    }
}