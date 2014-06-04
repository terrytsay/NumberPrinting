using System;

namespace NumberPrinting
{
    public class NumberPrinter : INumberPrinter
    {
        private readonly INumberProcessor _processor;
        private readonly ITextPrinter _printer;

        public NumberPrinter(INumberProcessor processor, ITextPrinter printer)
        {
            if(ReferenceEquals(processor, null))
                throw new ArgumentNullException("processor");
            if(ReferenceEquals(printer, null))
                throw new ArgumentNullException("printer");

            _processor = processor;
            _printer = printer;
        }

        public void Print(int start, int end)
        {
            if(start > end)
                throw new ArgumentOutOfRangeException("start", "");

            for (int i = start; i <= end; i++)
            {
                var texts = _processor.Process(i);

                foreach (var text in texts)
                {
                    _printer.Write(text);
                }

                _printer.WriteLine();
            }
        }
    }
}