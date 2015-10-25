namespace ShortestOperationSequence.OperationProcessor
{
    using System;

    public class DoubleOperation : IOperationProcessor
    {
        public Func<int, int> Operation
        {
            get
            {
                return x => x / 2;
            }
        }

        public IOperationProcessor LeftSuccesor { get; set; }

        public IOperationProcessor RightSuccesor { get; set; }

        public int GetProcessedResult(int number, int goal)
        {
            if (this.CanProcess(number, goal))
            {
                if (this.ShouldProcess(number))
                {
                    return this.Operation(number);
                }
                else
                {
                    return this.RightSuccesor.GetProcessedResult(number, goal);
                }
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

        private bool ShouldProcess(int number)
        {
            return number % 2 == 0;
        }
    }
}
