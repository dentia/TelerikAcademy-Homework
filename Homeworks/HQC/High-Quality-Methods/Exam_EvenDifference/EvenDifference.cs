namespace Exam_EvenDifference
{
    using System;
    using System.Linq;

    internal class EvenDifference
    {
        internal static void Main()
        {
            long[] numbers = GetNumbers();
            long result = GetEvenDifferenceSum(numbers);
            Console.WriteLine(result);
        }

        private static long GetEvenDifferenceSum(long[] numbers)
        {
            long sum = 0;

            for (int ind = 1; ind < numbers.Length; ind++)
            {
                long difference = Math.Abs(numbers[ind] - numbers[ind - 1]);

                if (difference % 2 == 0)
                {
                    sum += difference;
                    ++ind;
                }
            }

            return sum;
        }

        private static long[] GetNumbers()
        {
            return Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();
        }
    }
}