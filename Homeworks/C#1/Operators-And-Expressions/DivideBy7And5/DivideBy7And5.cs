//Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.

namespace DivideBy7And5
{
    using System;
    class DivideBy7And5
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number to check: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("The number {0} be divided by 5 and 7 without a remainder.", IsDivisible(number) ? "CAN" : "CANNOT");
        }

        static bool IsDivisible(int number)
        {
            if (number % 35 != 0) return false;
            return true;
        }
    }
}
