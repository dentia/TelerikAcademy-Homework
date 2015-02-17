//Write a program that extracts from a given text all sentences containing given word.
//Consider that the sentences are separated by . and the words – by non-letter symbols.

namespace ExtractSentences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    class ExtractSentences
    {
        static void Main(string[] args)
        {
/*
We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
in
*/

            Console.Write("Enter some text: ");
            string text = Console.ReadLine();
            Console.Write("Enter a word to search for: ");
            string key = Console.ReadLine();
            
            string[] matches = GetMatches(text, key);
            if (matches.Length == 0)
            {
                Console.WriteLine(Environment.NewLine +
                    "No matches found!");
            }
            else
            {
                foreach (var sentence in matches)
                {
                    Console.WriteLine("- " + sentence);
                }
            }
        }

        private static string[] GetMatches(string text, string key)
        {
            char[] separators = { '.', '!', '?', ';' };
            string[] separateSentences = text
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> matches = new List<string>();

            foreach (var sentence in separateSentences)
            {
                if (Regex
                    .IsMatch(sentence.ToLower(),
                            String.Format("{0}{1}{2}", "(^|[.;,:!? -])", key.ToLower(), "([.;,:!? -]|$)"),
                            RegexOptions.IgnoreCase))
                {
                    matches.Add(sentence.Trim());
                }
            }

            return matches.ToArray();
        }
    }
}
