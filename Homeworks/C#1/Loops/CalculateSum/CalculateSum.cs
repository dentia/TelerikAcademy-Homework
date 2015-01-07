//Write a program that, for a given two integer numbers n and x, 
//calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn. Use only one loop. 
//Print the result with 5 digits after the decimal point.

namespace CalculateSum
{
    using System;
    using System.Numerics;
    class CalculateSum
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter X: ");
            int x = int.Parse(Console.ReadLine());
            decimal sum = 1;

            for (int number = 1; number <= n; number++)
            {
                sum += (decimal)Factorial(number) / (decimal)Math.Pow(x, number);
            }

            Console.WriteLine("Sum: {0:F5}", sum);
        }
        private static BigInteger Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
    }
}
