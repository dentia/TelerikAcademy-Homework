//Write a program that enters from the console a positive integer n and prints 
//all the numbers from 1 to n, on a single line, separated by a space.

namespace NumbersToN
{
    using System;
    using System.Text;
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a number: ");
            int range = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            if (range < 1)
                for (int number = 1; number >= range; number--)
                        result.Append(number + " ");


            else
                for (int number = 1; number <= range; number++)
                    if (number % 3 != 0 || number % 7 != 0)
                        result.Append(number + " ");

            Console.WriteLine(result);
        }
    }
}
