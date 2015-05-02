// Write a program that reads from the console a
// sequence of positive integer numbers. The sequence
// ends when empty line is entered. Calculate and print
// the sum and average of the elements of the
// sequence. Keep the sequence in List<int>

namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    class SumAndAverage
    {
        static void Main()
        {
            List<int> numbers = Common.ReadInput();
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Avg: " + numbers.Average());
            
        }
    }
}
