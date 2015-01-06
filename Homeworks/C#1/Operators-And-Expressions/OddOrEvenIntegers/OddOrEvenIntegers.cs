//Write an expression that checks if given integer is odd or even.

namespace OddOrEvenIntegers
{
    using System;
    class OddOrEvenIntegers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number to check: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("The number is {0}.", IsEven(number) ? "EVEN" : "ODD");
        }

        static bool IsEven(int number)
        {
            if (number % 2 == 1) return false;
            return true;
        }
    }
}
