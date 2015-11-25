namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnapsackProblem
    {
        public static void Main()
        {
            /* Sample input
               10
               6
               beer – weight=3, cost=2
               vodka – weight=8, cost=12
               cheese – weight=4, cost=5
               nuts – weight=1, cost=4
               ham – weight=2, cost=3
               whiskey – weight=8, cost=13
             */

            var maxCapacity = int.Parse(Console.ReadLine());
            var itemsCount = int.Parse(Console.ReadLine());
            var items = Enumerable.Range(0, itemsCount)
                .Select(x => Item.Parse(Console.ReadLine()))
                .ToList();

            var dynamic = new int[itemsCount + 1, maxCapacity + 1];
            var backtrack = new int[itemsCount + 1, maxCapacity + 1];

            CalculateValues(itemsCount, items, maxCapacity, dynamic, backtrack);

            int index;
            var max = GetMaxValue(maxCapacity, dynamic, itemsCount, out index);
            Console.WriteLine(max);

            PrintTakenItems(itemsCount, dynamic, index, items, backtrack);
        }

        private static void PrintTakenItems(int itemsCount, int[,] dynamic, int index, List<Item> items, int[,] backtrack)
        {
            for (var i = itemsCount; i > 0; i--)
            {
                if (dynamic[i, index] == dynamic[i - 1, index])
                {
                    continue;
                }

                Console.WriteLine(items[i - 1].Name);
                index = backtrack[i, index];
            }
        }

        private static int GetMaxValue(int maxCapacity, int[,] dynamic, int itemsCount, out int index)
        {
            var max = 0;
            index = 0;
            for (var i = 0; i < maxCapacity + 1; i++)
            {
                if (dynamic[itemsCount, i] <= max)
                {
                    continue;
                }

                max = dynamic[itemsCount, i];
                index = i;
            }

            return max;
        }

        private static void CalculateValues(int itemsCount, List<Item> items, int maxCapacity, int[,] dynamic, int[,] backtrack)
        {
            for (var i = 1; i <= itemsCount; i++)
            {
                var item = items[i - 1];

                for (var j = 1; j <= maxCapacity; j++)
                {
                    var notUsedValue = dynamic[i - 1, j];
                    var usedValue = 0;

                    if (j - item.Weight >= 0)
                    {
                        usedValue = dynamic[i - 1, j - item.Weight] + item.Cost;
                    }

                    if (usedValue >= notUsedValue && usedValue != 0)
                    {
                        dynamic[i, j] = usedValue;
                        backtrack[i, j] = j - item.Weight;
                    }
                    else
                    {
                        dynamic[i, j] = notUsedValue;
                    }
                }
            }
        }
    }
}
