namespace ShortestOperationSequence.OperationProcessor
{
    using System;

    public class PlusTwoOperation : IOperationProcessor
    {
        public Func<int, int> Operation
        {
            get
            {
                return x => x - 2;
            }
        }

        public IOperationProcessor LeftSuccesor { get; set; }

        public IOperationProcessor RightSuccesor { get; set; }

        public int GetProcessedResult(int number, int goal)
        {
            if (this.CanProcess(number, goal))
            {
                return this.Operation(number);
            }
            else
            {
                return this.LeftSuccesor.GetProcessedResult(number, goal);
            }
        }

        public bool CanProcess(int number, int goal)
        {
            return this.Operation(number) >= goal;
        }
    }
}
