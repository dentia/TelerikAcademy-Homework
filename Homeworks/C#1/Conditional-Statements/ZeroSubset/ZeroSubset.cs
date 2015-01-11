//We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
//Assume that repeating the same subset several times is not a problem.

namespace ZeroSubset
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ZeroSubset
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers separated by space: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.Write("Enter sum: ");
            int sum = 0;

            List<string> allSubsets = new List<string>();


            SubsetSumGenerator generator = new SubsetSumGenerator(sum, numbers);
            allSubsets = generator.GetAllSums();
            if (allSubsets.Count == 0) allSubsets.Add("No subset sums found!");


            Console.Clear();
            allSubsets = allSubsets.Distinct().ToList();
            Console.WriteLine("All subsets: \n");
            Console.WriteLine(string.Join("\n", allSubsets));
        }
    }
}
