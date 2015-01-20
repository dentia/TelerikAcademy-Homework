//Write a program that finds the maximal increasing sequence in an array. Example: 
//{3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

namespace LongestIncreasingSequence
{
    using System;
    using System.Linq;
    class LongestIncreasingSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array of integers separated by space: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var sequence = GetLongestSequence(numbers);
            Console.WriteLine("Longest sequence: " + sequence);
        }

        private static string GetLongestSequence(int[] numbers)
        {
            int lastSequenceIndex = 0;
            int longestSequenceLenght = 1;
            int tempLenght = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] - 1 == numbers[i - 1])
                {
                    ++tempLenght;
                    if (tempLenght > longestSequenceLenght)
                    {
                        longestSequenceLenght = tempLenght;
                        lastSequenceIndex = i;
                    }
                }
                else
                {
                    tempLenght = 1;
                }
            }

            int skip = lastSequenceIndex - longestSequenceLenght + 1;
            var sequence = numbers.Skip(skip).Take(longestSequenceLenght).ToArray();
            return string.Join(", ", sequence);
        }
    }
}
