namespace CombinationsWithoutDuplicates
{
    using System;
    using System.Collections.Generic;

    public static class CombinationsWithoutDuplicates
    {
        public static void Main()
        {
            var result = new List<string>();
            result.PutCombinations(1, 4, new int[2], 0);
            Console.WriteLine(string.Join(", ", result));
        }

        private static void PutCombinations(this IList<string> output, int startNumer, int endNumber, int[] placeholder, int index)
        {
            if (index == placeholder.Length)
            {
                output.Add(string.Format("({0})", string.Join(" ", placeholder)));
                return;
            }

            for (var number = startNumer; number <= endNumber; number++)
            {
                placeholder[index] = number;
                output.PutCombinations(number + 1, endNumber, placeholder, index + 1);
            }
        }
    }
}
