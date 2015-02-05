//Write a method that reverses the digits of given decimal number.

namespace ReverseNumber
{
    using System;
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Reverse(number));
        }

        private static int Reverse(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result *= 10;
                result += number % 10;
                number /= 10;
            }
            return result;
        }
    }
}
