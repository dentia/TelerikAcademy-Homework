//We are given a string containing a list of forbidden words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks.

namespace ForbiddenWords
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    class ForbiddenWords
    {
        static void Main(string[] args)
        {
/*
Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
PHP, CLR, Microsoft
*/
            Console.Write("Enter some text: ");
            string text = Console.ReadLine();
            Console.Write("Enter forbidden words separated by a space: ");
            string[] forbiddenWords = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            Console.WriteLine(Environment.NewLine +
                Censore(text, forbiddenWords));
        }

        private static string Censore(string text, string[] forbiddenWords)
        {
            return Regex.Replace(text, String.Join("|", forbiddenWords), delegate(Match match)
            {
                string current = match.ToString();
                return Regex.Replace(current, current, new String('*', current.Length));
            }, RegexOptions.IgnoreCase);
        }
    }
}
