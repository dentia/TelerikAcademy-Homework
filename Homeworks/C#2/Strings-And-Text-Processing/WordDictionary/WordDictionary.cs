// A dictionary is stored as a sequence of text lines containing words and their explanations.
// Write a program that enters a word and translates it by using the dictionary.

namespace WordDictionary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Script.Serialization;
    class WordDictionary
    {
        static readonly Dictionary<string, string> keywords = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            FillDictionary();

            Console.Write("Enter a C# keyword: ");
            string keyword = Console.ReadLine().ToLower().Trim();

            PrintDescription(keyword);
        }

        private static void PrintDescription(string keyword)
        {
            if (!keywords.ContainsKey(keyword))
            {
                Console.WriteLine("No matches found!");
                return;
            }

            Console.WriteLine("{0}  -  {1}", keyword.ToUpper(), keywords[keyword]);
        }

        private static void FillDictionary()
        {
            var serializer = new JavaScriptSerializer();

            StreamReader reader = new StreamReader(@"../../Keywords.json");
            string json = reader.ReadToEnd();

            List<Keyword> words = serializer.Deserialize<List<Keyword>>(json);
            foreach (var word in words)
            {
                keywords.Add(word.Word, word.Description);
            }
        }
    }
}
