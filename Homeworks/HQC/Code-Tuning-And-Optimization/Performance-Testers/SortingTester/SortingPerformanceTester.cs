namespace SortingTester
{
    using System;
    using System.Diagnostics;

    public static class SortingPerformanceTester
    {
        private static readonly int[] ReversedInt = new int[] { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private static readonly double[] ReversedDouble = new double[] { 15.5, 14.5, 13.5, 12.5, 11.5, 10.5, 9.5, 8.5, 7.5, 6.5, 5.5, 4.5, 3.5, 2.5, 1.5 };
        private static readonly string[] ReversedString = new string[] { "P", "O", "N", "M", "L", "K", "J", "I", "H", "G", "F", "E", "D", "C", "B", "A" };
        private static readonly int[] SortedInt = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        private static readonly double[] SortedDouble = new double[] { 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5, 8.5, 9.5, 10.5, 11.5, 12.5, 13.5, 14.5, 15.5 };
        private static readonly string[] SortedString = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P" };
        private static readonly int[] RandomInt = new int[] { 4, 5, 10, 6, 3, 11, 8, 13, 14, 9, 15, 2, 12, 7, 1 };
        private static readonly double[] RandomDouble = new double[] { 3.5, 5.5, 10.5, 11.5, 6.5, 4.5, 9.5, 12.5, 13.5, 7.5, 8.5, 1.5, 14.5, 15.5, 2.5, };
        private static readonly string[] RandomString = new string[] { "C", "F", "K", "L", "G", "D", "E", "B", "N", "A", "O", "H", "M", "P", "I", "J" };
        private static Stopwatch stopwatch = new Stopwatch();

        static SortingPerformanceTester()
        {
            ConsoleColor defaulft = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Every sorthing method asserts that the end result is a sorted array, so there's no need to print it." + Environment.NewLine);

            Console.ForegroundColor = defaulft;
        }

        private enum Type
        {
            Integer,
            Double,
            String
        }

        public static void TestSort(Algorithm algorithm, CollectionState state)
        {
            Console.WriteLine("**{0}; Collection state: {1}", algorithm, state);

            int[] workIntArray = GetCollection<int>(state, Type.Integer);
            TestSort(workIntArray, algorithm, Type.Integer);

            double[] workDoubleArray = GetCollection<double>(state, Type.Double);
            TestSort(workDoubleArray, algorithm, Type.Double);

            string[] workStringArray = GetCollection<string>(state, Type.String);
            TestSort(workStringArray, algorithm, Type.String);
        }

        private static T[] GetCollection<T>(CollectionState state, Type type) where T : IComparable
        {
            switch (state)
            {
                case CollectionState.Random:
                    if (type == Type.Integer)
                    {
                        return (T[])RandomInt.Clone();
                    }
                    else if (type == Type.Double)
                    {
                        return (T[])RandomDouble.Clone();
                    }
                    else if (type == Type.String)
                    {
                        return (T[])RandomString.Clone();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                case CollectionState.Sorted:
                    if (type == Type.Integer)
                    {
                        return (T[])SortedInt.Clone();
                    }
                    else if (type == Type.Double)
                    {
                        return (T[])SortedDouble.Clone();
                    }
                    else if (type == Type.String)
                    {
                        return (T[])SortedString.Clone();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                case CollectionState.Reversed:
                    if (type == Type.Integer)
                    {
                        return (T[])ReversedInt.Clone();
                    }
                    else if (type == Type.Double)
                    {
                        return (T[])ReversedDouble.Clone();
                    }
                    else if (type == Type.String)
                    {
                        return (T[])ReversedString.Clone();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                default:
                    throw new ArgumentException();
            }
        }

        private static void TestSort<T>(T[] collection, Algorithm algorithm, Type type) where T : IComparable
        {
            Console.Write(type + "\t");
            stopwatch.Reset();
            stopwatch.Start();

            switch (algorithm)
            {
                case Algorithm.SelectionSort:
                    SortingAlgorithms.SelectionSort(collection);
                    break;
                case Algorithm.InsertionSort:
                    SortingAlgorithms.InsertionSort(collection);
                    break;
                case Algorithm.QuickSort:
                    SortingAlgorithms.QuickSort(collection);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
