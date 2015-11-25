namespace KnapsackProblem
{
    using System.Linq;

    public class Item
    {
        private Item(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int Cost { get; private set; }

        public static Item Parse(string item)
        {
            var parts = item.Split('-');
            var name = parts[0].Trim();

            var info = parts[1].Split(',').Select(
                x =>
                    {
                        var toSplitPosition = x.IndexOf('=');
                        return int.Parse(x.Substring(toSplitPosition + 1));
                    })
                    .ToArray();
            var weight = info[0];
            var cost = info[1];

            return new Item(name, weight, cost);
        }
    }
}
