// Write a program that removes from given sequence
// all numbers that occur odd number of times.

namespace RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    class RemoveOddOccurences
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers on separate lines. The sequence should end with an empty line.");
            List<int> numbers = Common.ReadInput();
            for (var ind = 0; ind < numbers.Count; ind++)
            {
                var num = numbers[ind];
                if (numbers.Count(number => number == num) % 2 == 1)
                {
                    numbers.RemoveAll(number => number == num);
                    ind--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
