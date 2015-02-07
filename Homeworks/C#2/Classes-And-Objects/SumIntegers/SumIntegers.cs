//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.
namespace SumIntegers
{
    using System;
    using System.Linq;
    class SumIntegers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers, separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.WriteLine("The sum is: " + numbers.Sum());
        }
    }
}
