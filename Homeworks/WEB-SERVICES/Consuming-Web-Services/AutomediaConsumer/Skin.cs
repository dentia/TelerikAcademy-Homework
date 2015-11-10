namespace AutomediaConsumer
{
    using System;
    using System.Text;

    public class Skin
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Uri Icon { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("Name: {0}", this.Name).AppendLine();
            result.AppendFormat("Type: {0}", this.Type).AppendLine();
            result.AppendFormat("Icon URL: {0}", this.Icon).AppendLine();

            return result.ToString();
        }
    }
}
