namespace PrintArrayStatistics
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;

    public static class DoubleArrayExtensionMethods
    {
        public static void PrintStatistics<T>(this T[] numbers)
            where T : IComparable
        {
            StringBuilder statistics = new StringBuilder();
            statistics.AppendFormat("Min: {0}", numbers.GetMin()).AppendLine();
            statistics.AppendFormat("Max: {0}", numbers.GetMax()).AppendLine();
            statistics.AppendFormat("Avg: {0:F4}", numbers.GetAvg());

            Console.WriteLine(statistics);
        }

        public static T GetMin<T>(this T[] numbers) 
            where T : IComparable
        {
            return numbers.Min();
        }

        public static T GetMax<T>(this T[] numbers)
            where T : IComparable
        {
            return numbers.Max();
        }

        public static T GetAvg<T>(this T[] numbers) 
            where T : IComparable
        {
            dynamic sum = 0;

            for (int ind = 0; ind < numbers.Length; ind++)
            {
                sum = sum + numbers[ind];
            }

            return (T)(sum / numbers.Length);
        }
    }
}
