//Write a method that returns the last digit of given integer as an English word.

namespace EnglishDigit
{
    using System;
    class EnglishDigit
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine((Digit)(number % 10));
        }
    }
}
