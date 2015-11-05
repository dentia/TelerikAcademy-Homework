namespace CountNumbersOccurense
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .GroupBy(x => x)
                .OrderBy(x => x.Key)
                .ToList()
                .ForEach((x) =>
                {
                    Console.WriteLine("{0} -> {1}", x.Key, x.Count());
                });
        }
    }
}
