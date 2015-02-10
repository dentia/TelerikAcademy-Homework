//Write a program that finds the index of given element in a sorted array 
//of integers by using the binary search algorithm.

namespace BinarySearch
{
    using System;
    using System.Linq;
    class BinarySearch
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToArray();

            Console.Write("Enter a number to search for: ");
            int number = int.Parse(Console.ReadLine());

            int index = GetIndex(numbers, number, 0, numbers.Length - 1);
            Console.WriteLine(index);
        }

        private static int GetIndex(int[] numbers, int number, int low, int high)
        {
            if (high < low) 
                return -1;

            int mid = (low + high) / 2;

            if (numbers[mid] < number)
                return GetIndex(numbers, number, mid + 1, high);
            else if (numbers[mid] > number)
                return GetIndex(numbers, number, low, mid - 1);
            else
                return mid;
        }
    }
}
