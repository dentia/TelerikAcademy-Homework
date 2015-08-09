// Write a method that finds the longest subsequence
// of equal numbers in given List<int> and returns
// the result as new List<int>. Write a program to
// test whether the method works correctly.

namespace LongestEqualSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestEqualSequence
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            List<int> longestSequence = GetLongestSequence(numbers);
            Console.WriteLine("[{0}], count: {1}", string.Join(", ", longestSequence), longestSequence.Count);
        }

        private static List<int> GetLongestSequence(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list cannot be null or empty.");
            }

            int bestCount = 1;
            int bestElement = numbers[0];
            int count = 1;

            for (var ind = 1; ind < numbers.Count; ind++)
            {
                while (ind < numbers.Count && numbers[ind] == numbers[ind - 1])
                {
                    ++count;
                    ++ind;
                }

                if (count > bestCount)
                {
                    bestCount = count;
                    bestElement = numbers[ind - 1];
                }

                count = 1;
            }

                return Enumerable.Repeat(bestElement, bestCount).ToList();
        }
    }
}
