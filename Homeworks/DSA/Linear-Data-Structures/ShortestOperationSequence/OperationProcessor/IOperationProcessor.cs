namespace ShortestOperationSequence.OperationProcessor
{
    using System;

    public interface IOperationProcessor
    {
        Func<int, int> Operation { get; }
        
        IOperationProcessor LeftSuccesor { get; set; }

        IOperationProcessor RightSuccesor { get; set; }

        int GetProcessedResult(int number, int goal);

        bool CanProcess(int number, int goal);
    }
}
