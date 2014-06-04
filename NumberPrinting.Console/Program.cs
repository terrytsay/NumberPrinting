using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberPrinting.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new NumberPrinter(1, 100, new ConsoleTextPrinter());

            var inputs = Enumerable.Range(1, 100);

            foreach (var input in inputs)
            {
                printer.Print(input);
                System.Console.WriteLine();
            }

            System.Console.ReadLine();
        }
    }
}
