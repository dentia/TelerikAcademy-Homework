//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is workings correctly.

namespace AppearanceCount
{
    using System;
    using System.Linq;
    public class AppearanceCount
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers, separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.Write("Enter number to search for: ");
            int numberToCount = int.Parse(Console.ReadLine());

            int count = CountElementAppearance(numbers, numberToCount);

            Console.WriteLine("{0} -> {1} times", numberToCount, count);

        }

        public static int CountElementAppearance(int[] numbers, int numberToCount)
        {
            return numbers
                .Where(x => x == numberToCount)
                .Count();
        }
    }
}
