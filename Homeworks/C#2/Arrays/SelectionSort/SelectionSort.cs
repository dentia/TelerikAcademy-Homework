//Sorting an array means to arrange its elements in increasing order. 
//Write a program to sort an array. Use the "selection sort" algorithm: 
//Find the smallest element, move it at the first position, 
//find the smallest from the rest, move it at the second position, etc.

namespace SelectionSort
{
    using System;
    using System.Linq;
    class SelectionSort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            numbers = Sort(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static int[] Sort(int[] numbers)
        {
            int[] sorted = new int[numbers.Length];

            for (int index = 0; index < sorted.Length; index++)
            {
                int tempIndex = Array.IndexOf(numbers, numbers.Min());
                sorted[index] = numbers[tempIndex];
                numbers[tempIndex] = Int32.MaxValue;
            }

            return sorted;
        }
    }
}
