//Write a program that reads 3 real numbers from the console and prints their sum.

namespace SumOfThreeNumbers
{
    using System;
    class SumOfThreeNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three numbers: ");
            double sum = 0;

            for (int i = 0; i < 3; i++)
            {
                sum += double.Parse(Console.ReadLine());
            }

            Console.WriteLine("The sum is {0:F2}", sum);
        }
    }
}
