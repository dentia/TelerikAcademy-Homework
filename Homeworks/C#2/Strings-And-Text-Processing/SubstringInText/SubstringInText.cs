//Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

namespace SubstringInText
{
    using System;
    using System.Text.RegularExpressions;
    class SubstringInText
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some text: ");
            string text = Console.ReadLine();

            Console.Write("Enter substring to search for: ");
            string substring = Console.ReadLine();

            Console.WriteLine(GetSubstringOccurenceCount(text, substring));
        }

        private static int GetSubstringOccurenceCount(string text, string substring)
        {
            return Regex
                .Matches(text, substring, RegexOptions.IgnoreCase)
                .Count;
        }
    }
}
