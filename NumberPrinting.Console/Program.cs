namespace NumberPrinting.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var processor = new NumberProcessor(1, 100);
            processor.AddHandler(new DivisibleBy3PrintFizz());
            processor.AddHandler(new DivisibleBy5PrintBuzz());
            var textPrinter = new ConsoleTextPrinter();

            var printer = new NumberPrinter(processor, textPrinter);

            printer.Print(1, 100);

            System.Console.ReadLine();
        }
    }
}