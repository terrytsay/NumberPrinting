namespace NumberPrinting.Tests
{
    class DivisibleBy5PrintBuzz : INumberHandler
    {
        public ExecutionResult Handle(int number)
        {
            if (number % 5 == 0)
                return new ExecutionResult("Buzz");
            return ExecutionResult.NotHandled;
        }
    }
}