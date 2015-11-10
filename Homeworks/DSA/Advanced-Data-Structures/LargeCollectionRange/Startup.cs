namespace LargeCollectionRange
{
    using System;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main()
        {
            var productsByPrice = new OrderedMultiDictionary<int, string>(false);

            for (int product = 0; product < 500000; product++)
            {
                productsByPrice.Add(product, string.Format("Product#{0}", product));
            }

            var output = new StringBuilder();

            for (int range = 0; range < 10000; range++)
            {
                var result = productsByPrice.Range(range, true, range * 50, true).Take(20);
                output.AppendLine(string.Join(", ", result.Select(x => x.Value))).AppendLine();
            }

            Console.WriteLine(output);
        }
    }
}
