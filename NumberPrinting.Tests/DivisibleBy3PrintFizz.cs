namespace NumberPrinting.Tests
{
    class DivisibleBy3PrintFizz : INumberHandler
    {
        public ExecutionResult Handle(int number)
        {
            if(number % 3 == 0)
                return new ExecutionResult("Fizz");
            return ExecutionResult.NotHandled;
        }
    }
}