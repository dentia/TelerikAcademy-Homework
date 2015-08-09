namespace MathOperationsTest
{
    using System;
    using System.Diagnostics;

    public static class OperationPerformanceTester
    {
        private const int OperatingValueInteger = 1;
        private const long OperatingValueLong = 1L;
        private const float OperatingValueFloat = 1.0F;
        private const double OperatingValueDouble = 1.0;
        private const decimal OperatingValueDecimal = 1.0M;
        private const int RepeatOperationsCount = 1000000;
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        static OperationPerformanceTester()
        {
            Console.WriteLine("The program tests every operation 1M times with all variables set at value 1.");
        }

        public static void TestPerformance(Operation operation)
        {
            Console.WriteLine(operation);

            int resultInt = OperatingValueInteger;
            Stopwatch.Start();

            for (int i = 0; i < RepeatOperationsCount; i++)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        resultInt += OperatingValueInteger;
                        break;
                    case Operation.Subtraction:
                        resultInt -= OperatingValueInteger;
                        break;
                    case Operation.Multiplication:
                        resultInt *= OperatingValueInteger;
                        break;
                    case Operation.Division:
                        resultInt /= OperatingValueInteger;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Stopwatch.Stop();
            Console.WriteLine("{0,-20}:{1}", "Int", Stopwatch.Elapsed);
            Stopwatch.Reset();

            long resultLong = OperatingValueLong;
            Stopwatch.Start();

            for (int i = 0; i < RepeatOperationsCount; i++)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        resultLong += OperatingValueLong;
                        break;
                    case Operation.Subtraction:
                        resultLong -= OperatingValueLong;
                        break;
                    case Operation.Multiplication:
                        resultLong *= OperatingValueLong;
                        break;
                    case Operation.Division:
                        resultLong /= OperatingValueLong;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Stopwatch.Stop();
            Console.WriteLine("{0,-20}:{1}", "Long", Stopwatch.Elapsed);
            Stopwatch.Reset();

            float resultFloat = OperatingValueFloat;
            Stopwatch.Start();

            for (int i = 0; i < RepeatOperationsCount; i++)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        resultFloat += OperatingValueFloat;
                        break;
                    case Operation.Subtraction:
                        resultFloat -= OperatingValueFloat;
                        break;
                    case Operation.Multiplication:
                        resultFloat *= OperatingValueFloat;
                        break;
                    case Operation.Division:
                        resultFloat /= OperatingValueFloat;
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

            for (int i = 0; i < RepeatOperationsCount; i++)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        resultDouble += OperatingValueDouble;
                        break;
                    case Operation.Subtraction:
                        resultDouble -= OperatingValueDouble;
                        break;
                    case Operation.Multiplication:
                        resultDouble *= OperatingValueDouble;
                        break;
                    case Operation.Division:
                        resultDouble /= OperatingValueDouble;
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

            for (int i = 0; i < RepeatOperationsCount; i++)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        resultDecimal += OperatingValueDecimal;
                        break;
                    case Operation.Subtraction:
                        resultDecimal -= OperatingValueDecimal;
                        break;
                    case Operation.Multiplication:
                        resultDecimal *= OperatingValueDecimal;
                        break;
                    case Operation.Division:
                        resultDecimal /= OperatingValueDecimal;
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
