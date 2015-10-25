namespace ShortestOperationSequence.OperationProcessor
{
    using System;

    public class PlusOneOperation : IOperationProcessor
    {
        public Func<int, int> Operation
        {
            get
            {
                return x => x - 1;
            }
        }

        public IOperationProcessor LeftSuccesor { get; set; }

        public IOperationProcessor RightSuccesor { get; set; }

        public int GetProcessedResult(int number, int goal)
        {
                return this.Operation(number);
        }

        public bool CanProcess(int number, int goal)
        {
            return this.Operation(number) >= goal;
        }
    }
}
