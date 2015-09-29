namespace JSON_Processing
{
    using Newtonsoft.Json;

    public class Link
    {
        [JsonProperty("@rel")]
        public string Rel { get; set; }

        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
