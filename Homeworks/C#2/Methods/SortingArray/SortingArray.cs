//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.

namespace SortingArray
{
    using System;
    using System.Linq;
    class SortingArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers, separated by a comma: ");

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.Clear();

            Console.WriteLine("ASC");
            Sorter sorter = new Sorter(numbers);
            numbers = sorter.Sort(SortMethod.ASC);
            Console.WriteLine(String.Join(", ", numbers));

            Console.WriteLine("\nDESC");
            numbers = sorter.Sort(SortMethod.DESC);
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
