namespace StringVariations
{
    using System;
    using System.Collections.Generic;

    public static class StringVariations
    {
        public static void Main()
        {
            var result = new List<string>();
            result.PutCombinations(new[] { "hi", "a", "b" }, new string[2], 0);
            Console.WriteLine(string.Join(", ", result));
        }

        private static void PutCombinations(this IList<string> output, string[] elements, string[] placeholder, int index)
        {
            if (index == placeholder.Length)
            {
                output.Add(string.Format("({0})", string.Join(" ", placeholder)));
                return;
            }

            for (var ind = 0; ind < elements.Length; ind++)
            {
                placeholder[index] = elements[ind];
                output.PutCombinations(elements, placeholder, index + 1);
            }
        }
    }
}
