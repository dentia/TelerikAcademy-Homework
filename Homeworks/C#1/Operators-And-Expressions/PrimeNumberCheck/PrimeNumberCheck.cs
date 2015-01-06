//Write an expression that checks if given positive integer number n (n = 100) 
//is prime (i.e. it is divisible without remainder only to itself and 1).

namespace PrimeNumberCheck
{
    using System;
    class PrimeNumberCheck
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number to check: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("This number {0} prime.", IsPrime(number) ? "IS" : "is NOT");
        }

        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            for (int i = 2; i <= (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
