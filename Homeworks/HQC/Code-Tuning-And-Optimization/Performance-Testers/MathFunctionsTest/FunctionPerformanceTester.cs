namespace MathFunctionsTest
{
    using System;
    using System.Diagnostics;

    public static class FunctionPerformanceTester
    {
        private const float OperatingValueFloat = 100.0F;
        private const double OperatingValueDouble = 100.0;
        private const decimal OperatingValueDecimal = 100.0M;
        private const int RepeatFunctionsCount = 1000000;
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        static FunctionPerformanceTester()
        {
            Console.WriteLine("The program tests every operation 1M times with all variables set at value 100.0.");
        }

        public static void TestPerformance(Function function)
        {
            Console.WriteLine(function);

            // in the Math class float is implicitly casted to double
            float resultFloat = OperatingValueFloat;
            Stopwatch.Start();

            for (int i = 0; i < RepeatFunctionsCount; i++)
            {
                switch (function)
                {
                    case Function.Sqrt:
                        resultFloat = (float)Math.Sqrt(OperatingValueFloat);
                        break;
                    case Function.Sin:
                        resultFloat = (float)Math.Sin(OperatingValueFloat);
                        break;
                    case Function.Log:
                        resultFloat = (float)Math.Log(OperatingValueFloat);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Stopwatch.Stop();
            Console.WriteLine("{0,-20}:{1}", "Float", Stopwatch.Elapsed);
            Stopwatch.Reset();

            double resultDouble = OperatingValueDouble;
            Stopwatch.Start();

            for (int i = 0; i < RepeatFunctionsCount; i++)
            {
                switch (function)
                {
                    case Function.Sqrt:
                        resultDouble = Math.Sqrt(OperatingValueDouble);
                        break;
                    case Function.Sin:
                        resultDouble = Math.Sin(OperatingValueDouble);
                        break;
                    case Function.Log:
                        resultDouble = Math.Log(OperatingValueDouble);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Stopwatch.Stop();
            Console.WriteLine("{0,-20}:{1}", "Double", Stopwatch.Elapsed);
            Stopwatch.Reset();

            decimal resultDecimal = OperatingValueDecimal;
            Stopwatch.Start();

            for (int i = 0; i < RepeatFunctionsCount; i++)
            {
                switch (function)
                {
                    case Function.Sqrt:
                        resultDecimal = (decimal)Math.Sqrt((double)OperatingValueDecimal);
                        break;
                    case Function.Sin:
                        resultDecimal = (decimal)Math.Sin((double)OperatingValueDecimal);
                        break;
                    case Function.Log:
                        resultDecimal = (decimal)Math.Log((double)OperatingValueDecimal);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Stopwatch.Stop();
            Console.WriteLine("{0,-20}:{1}", "Decimal", Stopwatch.Elapsed);
            Stopwatch.Reset();
        }
    }
}
