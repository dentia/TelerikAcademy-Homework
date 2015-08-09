//Write a program that converts a string to a sequence of C# Unicode character literals.
//Use format strings.

namespace UnicodeCharacters
{
    using System;
    using System.Text;
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some text: ");
            string text = Console.ReadLine();

            Console.WriteLine(ParseToUnicode(text));
        }

        private static string ParseToUnicode(string text)
        {
            StringBuilder result = new StringBuilder();

            foreach (var letter in text)
            {
                result.Append(String.Format("\\u{0:X4}", (int)letter));
            }

            return result.ToString();
        }
    }
}
