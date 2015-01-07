//Write a program that shows the sign (+, - or 0) 
//of the product of three real numbers, without calculating it.

namespace MultiplicationSign
{
    using System;
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            int valueSigns = 0;
            Console.Write("Enter the first number: ");
            valueSigns += ValueSign(int.Parse(Console.ReadLine()));
            Console.Write("Enter the second number: ");
            valueSigns += ValueSign(int.Parse(Console.ReadLine()));
            Console.Write("Enter the third number: ");
            valueSigns += ValueSign(int.Parse(Console.ReadLine()));

            if (valueSigns >= 10) Console.WriteLine("The product is ZERO(0).");
            else
            {
                Console.WriteLine("The sign is {0}.", (valueSigns % 2 == 0) ? "PLUS(+)" : "MINUS(-)");
            }
        }

        private static int ValueSign(int number)
        {
            if (number < 0) return 1;
            if (number == 0) return 10;
            return 0;
        }
    }
}
