//Write a program that reads a string, reverses it and prints the result at the console.

namespace ReverseString
{
    using System;
    class ReverseString
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            string input = Console.ReadLine();

            Console.WriteLine(StringReverse(input));
        }

        static string StringReverse(string input)
        {
            char[] inputArr = input.ToCharArray();
            Array.Reverse(inputArr);
            return new String(inputArr);
        }
    }
}
