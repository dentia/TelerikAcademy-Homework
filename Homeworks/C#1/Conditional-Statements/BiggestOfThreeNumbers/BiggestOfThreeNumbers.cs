//Write a program that finds the biggest of three numbers.
namespace BiggestOfThreeNumbers
{
    using System;
    class BiggestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number: ");
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine("Nested loops: " + BiggestWithNestedLoops(first, second, third));
            Console.WriteLine("Math.Max: " + Math.Max(Math.Max(first, second), third));
        }

        private static string BiggestWithNestedLoops(int first, int second, int third)
        {
            if (first > second)
            {
                if (first > third)
                {
                    return first.ToString();
                }
                else
                {
                    return third.ToString();
                }
            }
            else
            {
                if (second > third)
                {
                    return second.ToString();
                }
                else
                {
                    return third.ToString();
                }
            }
        }
    }
}
