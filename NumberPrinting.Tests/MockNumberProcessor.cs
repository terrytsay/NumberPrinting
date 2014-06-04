using System.Collections.Generic;

namespace NumberPrinting.Tests
{
    class MockNumberProcessor : INumberProcessor
    {
        private Dictionary<int, ICollection<string>> _map = new Dictionary<int, ICollection<string>>();

        public void Setup(int number, params string[] expectedOutput)
        {
            _map[number] = expectedOutput;
        }
        public IEnumerable<string> Process(int number)
        {
            return _map[number];
        }
    }
}