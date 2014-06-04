namespace NumberPrinting.Console
{
    class ConsoleTextPrinter : ITextPrinter
    {
        public void Write(string text)
        {
            System.Console.Write("{0} ", text);
        }

        public void WriteLine()
        {
            System.Console.WriteLine();
        }
    }
}