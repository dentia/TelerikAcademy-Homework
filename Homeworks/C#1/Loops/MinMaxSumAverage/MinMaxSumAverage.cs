//Write a program that reads from the console a sequence of n integer 
//numbers and returns the minimal, the maximal number, the sum and the 
//average of all numbers (displayed with 2 digits after the decimal point).
//The input starts by the number n (alone in a line) followed by n lines, 
//each holding an integer number. The output is like in the examples below.

namespace MinMaxSumAverage
{
    using System;
    using System.Linq;
    class MinMaxSumAverage
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers count: ");
            int count = int.Parse(Console.ReadLine());

            if (count < 1)
            {
                Console.WriteLine("No numbers to work with.");
                return;
            }

            Console.WriteLine("Enter {0} numbers on separate lines: ", count);
            int[] numbers = Enumerable.Range(0, count)
                .Select(x => int.Parse(Console.ReadLine()))
                .ToArray();

            Console.WriteLine(GetResult(numbers));
        }

        private static string GetResult(int[] numbers)
        {
            int min = numbers.Min();
            int max = numbers.Max();
            long sum = numbers.Sum();
            double average = (double)sum / numbers.Length;

            return String.Format(@"
Min     {0}
Max     {1}
Sum     {2}
Average {3:F2}
", min, max, sum, average).Trim();
        }
    }
}
