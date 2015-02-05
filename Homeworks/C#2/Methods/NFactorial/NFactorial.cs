//Write a program to calculate n! for each n in the range [1..100].

namespace NFactorial
{
    using System;
    using System.Numerics;
    class NFactorial
    {
        static void Main(string[] args)
        {
            Factorial factorial = new Factorial(100);

            Console.WriteLine(factorial.Get(0));
            Console.WriteLine(factorial[10]);
            Console.WriteLine(factorial.Get(20));
            Console.WriteLine(factorial[30]);
        }
    }
}
