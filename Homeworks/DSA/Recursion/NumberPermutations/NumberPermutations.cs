namespace NumberPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class NumberPermutations
    {
        public static void Main()
        {
            var result = new List<string>();
            result.PutPermutations(1, 3, new int[3], 0);
            Console.WriteLine(string.Join(", ", result));
        }

        public static void PutPermutations(this List<string> output, int startNumber, int endNumber, int[] placeholder, int index)
        {
            if (index == placeholder.Length)
            {
                output.Add(string.Format("{{{0}}}", string.Join(", ", placeholder)));
                return;
            }

            for (int number = startNumber; number <= endNumber; number++)
            {
                if (placeholder.Contains(number))
                {
                    continue;
                }

                placeholder[index] = number;
                output.PutPermutations(startNumber, endNumber, placeholder, index + 1);
                placeholder[index] = 0;
            }
        }
    }
}
