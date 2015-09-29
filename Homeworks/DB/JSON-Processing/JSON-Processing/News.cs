namespace JSON_Processing
{
    using Newtonsoft.Json;

    public class News
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pubDate")]
        public string PublishedDate { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Title, this.PublishedDate, this.Link);
        }
    }
}
