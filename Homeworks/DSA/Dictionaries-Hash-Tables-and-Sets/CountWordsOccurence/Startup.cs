namespace CountWordsOccurence
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            Regex.Matches(Console.ReadLine(), "[A-Za-z0-9]+")
                .Cast<Match>()
                .Select(m => m.Value.ToLower())
                .GroupBy(x => x)
                .OrderBy(x => x.Count())
                .ToList()
                .ForEach((x) =>
                    {
                        Console.WriteLine("{0} -> {1}", x.Key, x.Count());
                    });
        }
    }
}
