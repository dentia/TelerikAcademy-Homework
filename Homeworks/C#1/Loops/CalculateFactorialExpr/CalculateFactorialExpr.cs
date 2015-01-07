//In combinatorics, the number of ways to choose k different members 
//out of a group of n different elements (also known as the number of combinations) 
//is calculated by the following formula: formula For example, there are 2598960 
//ways to withdraw 5 cards out of a standard deck of 52 cards.
//Your task is to write a program that calculates n! / (k! * (n-k)!) 
//for given n and k (1 < k < n < 100). Try to use only two loops.

namespace CalculateFactorialExpr
{
    using System;
    using System.Numerics;
    class CalculateFactorialExpr
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());

            BigInteger factN = Factorial(n);
            BigInteger factK = Factorial(k);
            BigInteger factNMinusK = Factorial(n-k);

            BigInteger result = factN / (factK * factNMinusK);

            Console.WriteLine("{0}! / ({1}! * ({0} - {1})!) = {2}", n, k, result);
        }

        private static BigInteger Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
    }
}
