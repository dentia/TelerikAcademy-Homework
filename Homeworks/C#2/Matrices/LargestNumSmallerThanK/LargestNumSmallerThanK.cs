//Write a program, that reads from the console an array 
//of N integers and an integer K, sorts the array and 
//using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

namespace LargestNumSmallerThanK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class LargestNumSmallerThanK
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers, separated by a comma: ");
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToList();

            Console.Write("Enter number K: ");
            int maxNum = int.Parse(Console.ReadLine());

            NumberComparer comparer = new NumberComparer();
            int index = numbers.BinarySearch(maxNum, comparer);

            if (index >= 0)
                Console.WriteLine(numbers[index]);
            else
            {
                index = Math.Abs(index) - 2;
                if (index >= 0)
                    Console.WriteLine(numbers[index]);
                else
                    Console.WriteLine("No numbers less than/equal to {0} were found!", maxNum);
            }
        }
    }
}
