//Write a program that reads from the console a positive integer number n 
//(1 = n = 20) and prints a matrix like in the examples below. Use two nested loops.

namespace MatrixOfNumbers
{
    using System;
    class MatrixOfNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            if (n < 1)
            {
                Console.WriteLine("No matrix can be printed.");
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < i + n; j++)
                {
                    Console.Write("{0,-4}", j);
                }
                Console.WriteLine();
            }
        }
    }
}
