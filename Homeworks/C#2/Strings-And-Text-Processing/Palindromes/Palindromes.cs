//Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.

namespace Palindromes
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    class Palindromes
    {
        static void Main(string[] args)
        {
            string sample = "Here are some palindromes: ABBA, exe, lamal. And here are some more - oohoo, SOS, lol. The following are not palindromes: cool, dot, tod, mike.";

            StringBuilder result = new StringBuilder();

            foreach (var match in Regex.Matches(sample, @"\w+"))
            {
                if (IsPalindrome(match.ToString()))
                {
                    result.AppendLine(match.ToString());
                }
            }

            if (result.Length == 0)
                result.AppendLine("No palindromes found!");

            Console.WriteLine(result);
        }

        private static bool IsPalindrome(string match)
        {
            for (int left = 0, right = match.Length-1; 
                left < match.Length/2; 
                left++, right--)
            {
                if (match[left] != match[right])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
