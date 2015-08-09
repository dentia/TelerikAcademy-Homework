//Write a program that finds the maximal sequence of equal elements in an array.
//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

namespace EqualElements
{
    using System;
    using System.Linq;
    class EqualElements
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            if (numbers.Length < 1)
                return;

            var result = GetResult(numbers);
            Console.WriteLine(string.Join(", ", result));
        }

        private static int[] GetResult(int[] numbers)
        {
            int bestInt = numbers[0];
            int maxLength = 0;
            int tempLength = 1;
            int lastInt = numbers[0];

            for (int number = 1; number < numbers.Length; number++)
            {
                if (numbers[number] != lastInt)
                {
                    tempLength = 1;
                    lastInt = numbers[number];
                }
                else
                {
                    ++tempLength;
                }

                if (tempLength > maxLength)
                {
                    maxLength = tempLength;
                    bestInt = numbers[number];
                }
            }

            return Enumerable.Range(0, maxLength).Select(x => bestInt).ToArray();
        }
    }
}
