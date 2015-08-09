//Write a program that finds in given array of integers a sequence 
//of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	

namespace GivenSumSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class GivenSumSequence
    {
        static void Main(string[] args)
        {
            int[] numbers = ("0, " + Console.ReadLine())
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.WriteLine("Enter SUM: ");
            int sum = int.Parse(Console.ReadLine());

            int[] cash = new int[numbers.Length];
            cash = FillCash(numbers, cash);

            string result = GetSubsets(numbers, cash, sum);
        }

        private static string GetSubsets(int[] numbers, int[] cash, int sum)
        {
            StringBuilder result = new StringBuilder();
            Dictionary<int, List<int>> subSums = new Dictionary<int, List<int>>();
            int currentSum;

            for (int currentIndex = 1; currentIndex < cash.Length; currentIndex++)
            {
                currentSum = cash[currentIndex] - sum;

                if (subSums.ContainsKey(currentSum)) //subsequence was found
                {
                    int subLength = currentIndex - subSums[currentSum][0];
                    int startIndex = subSums[currentSum][0] + 1;
                    int[] foundSequence = new int[subLength];
                    Array.Copy(numbers, startIndex, foundSequence, 0, subLength);

                    result.AppendLine("{" + string.Join(", ", foundSequence) + "}");
                    Console.WriteLine(result);
                }
                
                if (subSums.ContainsKey(cash[currentIndex])) //insert current index
                {
                    subSums[cash[currentIndex]].Insert(0, currentIndex);
                }
                else 
                {
                    List<int> indices = new List<int>();
                    indices.Add(currentIndex);
                    subSums.Add(cash[currentIndex], indices);
                }
            }

            if (result.Length == 0)
            {
                result.Append(String.Format("No subsequences with sum {0} were found!", sum));
            }

            return result.ToString();
        }

        private static int[] FillCash(int[] numbers, int[] cash)
        {
            for (int index = 1; index < cash.Length; index++)
            {
                cash[index] = cash[index - 1] + numbers[index];
            }

            return cash;
        }
    }
}
