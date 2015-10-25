namespace ShortestOperationSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ShortestOperationSequence.OperationProcessor;

    using Utils;

    public class StartUp
    {
        public static void Main()
        {
            var sequence = GetSequence(5, 16);
            sequence.ForEach(Console.WriteLine);
        }

        private static IEnumerable<int> GetSequence(int start, int end)
        {
            var sequence = new List<int>();
            var processor = GetProcessor();

            var currentNumber = end;
            sequence.Add(currentNumber);

            while (currentNumber > start)
            {
                currentNumber = processor.GetProcessedResult(currentNumber, start);
                sequence.Add(currentNumber);
            }

            return sequence.OrderBy(x => x);
        }

        private static IOperationProcessor GetProcessor()
        {
            var plusOneOperation = new PlusOneOperation();
            var plusTwoOperation = new PlusTwoOperation { LeftSuccesor = plusOneOperation };
            var doubleOperation = new DoubleOperation
                                      {
                                          RightSuccesor = plusOneOperation,
                                          LeftSuccesor = plusTwoOperation
                                      };

            return doubleOperation;
        }
    }
}
