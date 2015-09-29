namespace JSON_Processing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class TaskSolver
    {
        public IEnumerable<News> GetNews(JObject json)
        {
            var news = json["rss"]["channel"]["item"]
                .Select(i => JsonConvert.DeserializeObject<News>(i.ToString()));

            return news;
        }

        public string GetHtmlString(IEnumerable<News> news)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<!DOCTYPE html><html><body><ul>");
            foreach (var newsItem in news)
            {
                html.AppendFormat("<li><a href={0}>{1}</a> ({2})</li>", newsItem.Link, newsItem.Title, newsItem.PublishedDate);
            }
            html.Append("</ul></body></html>");

            return html.ToString();
        }

        public void DownloadRss(string url)
        {
            WebClient myWebClient = new WebClient { Encoding = Encoding.UTF8 };
            myWebClient.DownloadFile(url, "news.xml");
        }

        public XmlDocument GetXml(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc;
        }

        public JObject GetJsonObject(XmlDocument xmlDoc)
        {
            string json = JsonConvert.SerializeXmlNode(xmlDoc);
            var jsonObj = JObject.Parse(json);

            return jsonObj;
        }

        public IEnumerable<JToken> GetNewsTitles(JObject jsonObj)
        {
            return jsonObj["rss"]["channel"]["item"]
                .Select(item => item["title"]);
        }

        public void PrintTitles(IEnumerable<JToken> titles)
        {
            Console.WriteLine(string.Join(Environment.NewLine, titles));
        }

        public void SaveHtml(string html, string htmlName)
        {
            using (StreamWriter writer = new StreamWriter("../../" + htmlName, false, Encoding.UTF8))
            {
                writer.Write(html);
            }

            var currentDir = Directory.GetCurrentDirectory();
            var htmlDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug")) + htmlName;

            Console.WriteLine("Html dir: {0}", htmlDir);
        }
    }
}
