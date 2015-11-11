namespace RecursiveNestedLoops
{
    using System;
    using System.Text;

    public static class RecursiveNestedLoops
    {
        public static void Main()
        {
            var result = new StringBuilder();
            result.PutCombinations(1, 3, new int[3], 0);
            Console.WriteLine(result);
        }

        private static void PutCombinations(this StringBuilder output, int startNumer, int endNumber, int[] placeholder, int index)
        {
            if (index == placeholder.Length)
            {
                output.AppendLine(string.Join(" ", placeholder));
                return;
            }

            for (var number = startNumer; number <= endNumber; number++)
            {
                placeholder[index] = number;
                output.PutCombinations(startNumer, endNumber, placeholder, index + 1);
            }
        }
    }
}
