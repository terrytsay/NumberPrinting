using System.Collections.Generic;

namespace NumberPrinting
{
    public interface INumberProcessor
    {
        IEnumerable<string> Process(int number);
    }
}