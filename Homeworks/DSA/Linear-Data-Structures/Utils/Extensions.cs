namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public static class Extensions
    {
        public static void CopyArrayToClipboard(this int[] numbers)
        {
            var input = string.Join(Environment.NewLine, numbers) + Environment.NewLine + Environment.NewLine;
            Clipboard.SetText(input);
        }

        public static void CopyMatrixToClipboard(this string[][] matrix)
        {
            var input = new StringBuilder();

            foreach (var array in matrix)
            {
                input.AppendLine(string.Join(" ", array));
            }

            input.AppendLine();

            Clipboard.SetText(input.ToString());
        }

        public static IEnumerable<int> StackReverse(this IEnumerable<int> numbersList)
        {
            var result = new List<int>();
            var stack = new Stack<int>();

            numbersList.ForEach(x => stack.Push(x));
            stack.ForEach(x => result.Add(x));

            return result;
        }

        public static IEnumerable<int> GetLongestEqualSubsequence(this IEnumerable<int> numbersList)
        {
            var longestSubsequence = 0;
            var currentSubsequence = 0;
            var subsequenceNumber = default(int);

            for (var ind = 0; ind < numbersList.Count(); ind++)
            {
                var currentElement = numbersList.ElementAt(ind);

                if (ind == 0)
                {
                    currentSubsequence = 1;
                }
                else
                {
                    var previousElement = numbersList.ElementAt(ind - 1);

                    if (currentElement != previousElement)
                    {
                        currentSubsequence = 1;
                    }
                    else
                    {
                        ++currentSubsequence;
                    }
                }

                if (currentSubsequence > longestSubsequence)
                {
                    longestSubsequence = currentSubsequence;
                    subsequenceNumber = currentElement;
                }
            }

            return Enumerable.Repeat(subsequenceNumber, longestSubsequence).ToList();
        }

        public static IEnumerable<int> GetOnlyPositiveNumbers(this IEnumerable<int> numbersList)
        {
            var result = new List<int>();

            numbersList.ForEach(
                x =>
                    {
                        if (x >= 0)
                        {
                            result.Add(x);
                        }
                    });

            return result;
        }

        public static IEnumerable<int> RemoveOddOccurences(this IEnumerable<int> numbersList)
        {
            return numbersList.Where(x => numbersList.Count(y => y == x) % 2 == 0);
        }

        public static IDictionary<int, int> GetOccurenceCount(this IEnumerable<int> numbersList)
        {
            return numbersList.GroupBy(x => x).OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Count());
        }

        public static int? GetMajorant(this IEnumerable<int> numbersList)
        {
            var numbersCount = numbersList.Count();

            return numbersList.Cast<int?>()
                .FirstOrDefault(x => numbersList.Count(y => y == x) >= (numbersCount / 2) + 1);
        }

        public static IEnumerable<int> GetSpecialSequence(this int startNumber, int sequeceLength)
        {
            var result  = new List<int>();
            var queue = new Queue<int>();
            queue.Enqueue(startNumber);

            var counter = 0;
            while (counter < sequeceLength)
            {
                var element = queue.Dequeue();

                result.Add(element);

                queue.Enqueue(element + 1);
                queue.Enqueue((2 * element) + 1);
                queue.Enqueue(element + 2);

                counter += 3;
            }

            while (queue.Count > 0)
            {
                result.Add(queue.Dequeue());
            }

            return result.Take(sequeceLength);
        }

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration)
            {
                action(item);
            }
        }
    }
}
