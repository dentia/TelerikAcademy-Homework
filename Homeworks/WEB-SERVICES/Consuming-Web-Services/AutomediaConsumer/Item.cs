namespace AutomediaConsumer
{
    using System;
    using System.Text;

    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Rarity { get; set; }

        public Uri Icon { get; set; }

        public int Level { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("Name: {0}", this.Name).AppendLine();
            result.AppendFormat("Description: {0}", this.Description).AppendLine();
            result.AppendFormat("Rarity: {0}", this.Rarity).AppendLine();
            result.AppendFormat("Level: {0}", this.Level).AppendLine();
            result.AppendFormat("Icon URL: {0}", this.Icon).AppendLine();

            return result.ToString();
        }
    }
}
