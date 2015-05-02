// Write a program that finds in given array of integers
// (all belonging to the range [0..1000]) how many
// times each of them occurs.
namespace CountOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    class CountOccurences
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers on separate lines. The sequence should end with an empty line.");
            List<int> numbers = Common.ReadInput();

            var groups = numbers.GroupBy(number => number).Select(group => group.ToArray()).OrderBy(group => group[0]);

            foreach (var group in groups)
            {
                Console.WriteLine("{0} -> {1}", group[0], group.Count());
            }
        }
    }
}

/*
3
4
4
2
3
3
4
3
2

 */