namespace ElementsWithOddOccurenceCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var result = new List<string>();

            Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(x => x)
                .ToList()
                .ForEach((x) =>
                    {
                        if (x.Count() % 2 == 1)
                        {
                            result.Add(x.Key);
                        }
                    });

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
