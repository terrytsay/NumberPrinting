using System;

namespace NumberPrinting
{
    public class ExecutionResult
    {
        private static readonly ExecutionResult NotHandledResult = new ExecutionResult();
        public static ExecutionResult NotHandled
        {
            get { return NotHandledResult; }
        }

        public ExecutionResult(string result)
        {
            if(result == null)
                throw new ArgumentNullException("result");
            Result = result;
        }
        private ExecutionResult()
        {
        }
        public bool IsHandled { get { return Result != null; } }
        public string Result { get; private set; }
    }
}