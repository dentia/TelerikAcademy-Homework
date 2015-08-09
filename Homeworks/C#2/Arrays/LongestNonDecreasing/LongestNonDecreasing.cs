//Write a program that reads an array of integers and 
//removes from it a minimal number of elements in such 
//way that the remaining array is sorted in increasing 
//order. Print the remaining sorted array. Example:
//{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

namespace LongestNonDecreasing
{
    using System;
    using System.Linq;
    class LongestNonDecreasing
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers, separated by a comma: ");
            int[] numbers = (int.MaxValue + " " + Console.ReadLine())
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();


            IncreasingSubsetCalculator subsetCalculator = new IncreasingSubsetCalculator(numbers);
            Console.WriteLine(subsetCalculator.GetSubset());
        }
    }
}
