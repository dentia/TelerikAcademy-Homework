//Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence 
//(at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

namespace FibonacciNumbers
{
    using System;
    using System.Numerics;
    class FibonacciNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter count: ");
            int count = int.Parse(Console.ReadLine());
            if (count < 1)
            {
                Console.WriteLine("No number to show.");
                return;
            }

            BigInteger[] fibonacciNumbers = new BigInteger[Math.Max(count, 3)];
            fibonacciNumbers[0] = 0;
            fibonacciNumbers[1] = 1;
            fibonacciNumbers[2] = 1;

            for (int index = 3; index < fibonacciNumbers.Length; index++)
            {
                fibonacciNumbers[index] = fibonacciNumbers[index - 1] + fibonacciNumbers[index - 2];
            }

            Console.WriteLine(string.Join(" ", fibonacciNumbers));
        }
    }
}
