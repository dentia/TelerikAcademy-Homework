namespace Guitar
{
    using System;
    using System.Linq;

    public class Guitar
    {
        public static void Main()
        {
            var changesCount = int.Parse(Console.ReadLine());

            var intervals = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var beginLevel = int.Parse(Console.ReadLine());
            var maxLevel = int.Parse(Console.ReadLine());

            var answer = GetFinalMax(intervals, changesCount, beginLevel, maxLevel);

            Console.WriteLine(answer);
        }

        private static int GetFinalMax(int[] changes, int changesCount, int beginLevel, int maxLevel)
        {
            var n = changesCount;
            var dynamic = new int[n + 1][];
            for (var i = 0; i < n + 1; i++)
            {
                dynamic[i] = new int[maxLevel + 1];
            }

            dynamic[0][beginLevel] = 1;
            for (var i = 1; i <= n; i++)
            {
                for (var j = 0; j <= maxLevel; j++)
                {
                    if (dynamic[i - 1][j] != 1)
                    {
                        continue;
                    }

                    var x = changes[i - 1];
                    if (j - x >= 0)
                    {
                        dynamic[i][j - x] = 1;
                    }

                    if (j + x <= maxLevel)
                    {
                        dynamic[i][j + x] = 1;
                    }
                }
            }

            for (var i = maxLevel; i >= 0; i--)
            {
                if (dynamic[n][i] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
