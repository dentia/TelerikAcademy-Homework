//Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
namespace SumOfFiveNumbers
{
    using System;
    using System.Linq;
    class SumOfFiveNumbers
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();

            Console.WriteLine("The sum is {0:F2}.", numbers.Sum());
        }
    }
}
