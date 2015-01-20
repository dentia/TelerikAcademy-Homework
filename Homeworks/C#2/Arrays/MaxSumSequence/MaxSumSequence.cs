//Write a program that finds the sequence of maximal sum in given array. Example:
//{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}

namespace MaxSumSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class MaxSumSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers, separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.Clear();

            if (numbers.Min() >= 0)
            {
                Console.WriteLine("{" + string.Join(", ", numbers) + "}");
                Console.WriteLine(numbers.Sum());
            }
            else if (numbers.Max() <= 0)
            {
                Console.WriteLine("{" + numbers.Max() + "}");
            }
            else
            {
                Console.WriteLine(GetBestSequence(numbers));
            }
        }

        private static string GetBestSequence(int[] numbers)
        {
            //Kadane's algorithm

            int tempSum = 0;
            int bestSum = 0;
            StringBuilder sequenceJoined = new StringBuilder();
            List<int> sequence = new List<int>();

            foreach (var number in numbers)
            {
                sequence.Add(number);
                tempSum += number;
                if (tempSum <= 0)
                {
                    tempSum = 0;
                    sequence.Clear();
                }
                else if (tempSum > bestSum)
                {
                    bestSum = tempSum;
                    sequenceJoined.Clear().AppendLine("{" + string.Join(", ", sequence) + "}");
                    sequenceJoined.AppendLine(bestSum.ToString());
                }
            }

            return sequenceJoined.ToString();
        }
    }
}
