namespace MathOperationsTest
{
    internal class MathOperationsTest
    {
        internal static void Main()
        {
            OperationPerformanceTester.TestPerformance(Operation.Addition);
            OperationPerformanceTester.TestPerformance(Operation.Subtraction);
            OperationPerformanceTester.TestPerformance(Operation.Multiplication);
            OperationPerformanceTester.TestPerformance(Operation.Division);
        }
    }
}
