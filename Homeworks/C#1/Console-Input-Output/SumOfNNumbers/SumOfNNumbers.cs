//Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.

namespace SumOfNNumbers
{
    using System;
    class SumOfNNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter count: ");
            int count = int.Parse(Console.ReadLine());
            if (count < 1)
            {
                Console.WriteLine("No numbers to sum.");
                return;
            }
            Console.WriteLine("Enter {0} numbers: ", count);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += double.Parse(Console.ReadLine());
            }

            Console.Clear();
            Console.WriteLine("The sum is {0:F2}.", sum);
        }
    }
}
