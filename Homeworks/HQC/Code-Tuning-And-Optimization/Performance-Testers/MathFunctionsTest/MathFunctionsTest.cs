namespace MathFunctionsTest
{
    internal class MathFunctionsTest
    {
        internal static void Main()
        {
            FunctionPerformanceTester.TestPerformance(Function.Sqrt);
            FunctionPerformanceTester.TestPerformance(Function.Log);
            FunctionPerformanceTester.TestPerformance(Function.Sin);
        }
    }
}
