// Write a program to compare the performance of
// insertion sort, selection sort, quicksort for int,
// double and string values. Check also the
// following cases: random values, sorted values,
// values sorted in reversed order.
namespace SortingTester
{
    using System;
    using System.Diagnostics;

    internal class SortingTester
    {
        internal static void Main()
        {
            string separator = Environment.NewLine + new string('-', 60) + Environment.NewLine;

            SortingPerformanceTester.TestSort(Algorithm.InsertionSort, CollectionState.Random);
            SortingPerformanceTester.TestSort(Algorithm.InsertionSort, CollectionState.Reversed);
            SortingPerformanceTester.TestSort(Algorithm.InsertionSort, CollectionState.Sorted);
            Console.WriteLine(separator);

            SortingPerformanceTester.TestSort(Algorithm.SelectionSort, CollectionState.Random);
            SortingPerformanceTester.TestSort(Algorithm.SelectionSort, CollectionState.Reversed);
            SortingPerformanceTester.TestSort(Algorithm.SelectionSort, CollectionState.Sorted);
            Console.WriteLine(separator);

            SortingPerformanceTester.TestSort(Algorithm.QuickSort, CollectionState.Random);
            SortingPerformanceTester.TestSort(Algorithm.QuickSort, CollectionState.Reversed);
            SortingPerformanceTester.TestSort(Algorithm.QuickSort, CollectionState.Sorted);
        }
    }
}
