namespace SortingAndSearchingAlgorithms
{
    using System;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("SelectionSorter result:");
            collection.Sort(new SelectionSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("Quicksorter result:");
            collection.Sort(new Quicksorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("MergeSorter result:");
            collection.Sort(new MergeSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Linear search 101:");
            Console.WriteLine(collection.LinearSearch(101));
            Console.WriteLine();

            Console.WriteLine("Binary search 101:");
            Console.WriteLine(collection.BinarySearch(101));
            Console.WriteLine();

            Console.WriteLine("Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }
    }
}
