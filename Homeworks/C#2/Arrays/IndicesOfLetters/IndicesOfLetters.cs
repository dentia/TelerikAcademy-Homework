//Write a program that creates an array containing all letters 
//from the alphabet (A-Z). Read a word from the console and 
//print the index of each of its letters in the array.

namespace IndicesOfLetters
{
    using System;
    using System.Text;
    using System.Linq;
    class IndicesOfLetters
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine().Trim().ToUpper();

            if (word
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray()
                .Count() != 1)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Console.WriteLine(GetIndices(word, Method.FromArray));
            Console.WriteLine(GetIndices(word, Method.UsingASCII));
        }

        private static string GetIndices(string word, Method method)
        {
            int[] indices = new int[word.Length];

            switch (method)
            {
                case Method.FromArray:
                    char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                    for (int index = 0; index < word.Length; index++)
                        indices[index] = Array.IndexOf(alphabet, word[index]);
                    break;
                case Method.UsingASCII:
                    for (int index = 0; index < word.Length; index++)
                        indices[index] = word[index] - 'A';
                    break;
                default:
                    return "Invalid method!";
            }

            Console.Write(method + "\t");
            return FormatIndices(indices);
        }

        private static string FormatIndices(int[] indices)
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < indices.Length; index++)
                result.Append(String.Format("[{0}/{1}]", (char)(indices[index] + 'A'), indices[index]));

            return result.ToString();
        }
    }
}
