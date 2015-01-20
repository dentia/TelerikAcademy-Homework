//Write a program that reads two integer numbers N and K and an 
//array of N elements from the console. 
//Find in the array those K elements that have maximal sum.

namespace MaxSumOfElements
{
    using System;
    using System.Linq;
    class MaxSumOfElements
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.Write("Enter number of elements to sum: ");
            int countElements = int.Parse(Console.ReadLine());

            if (countElements > numbers.Length)
            {
                Console.WriteLine("The array has less than {0} elements.", countElements);
                return;
            }

            numbers = numbers.OrderByDescending(x => x).ToArray();
            Console.WriteLine("The sum of the {0} largest numbers is {1}", 
                countElements, numbers.Take(countElements).Sum());
        }
    }
}
