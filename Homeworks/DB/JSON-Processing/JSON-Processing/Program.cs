namespace JSON_Processing
{
    using System;
    using System.Text;

    class Program
    {
        private const string RssLink = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
        private const string XmlPath = "videos.xml";
        private const string HtmlName = "index.html";

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            TaskSolver.DownloadRss(RssLink, XmlPath);
            var xmlDoc = TaskSolver.GetXml(XmlPath);
            var jsonObj = TaskSolver.GetJsonObject(xmlDoc);
            var titles = TaskSolver.GetVideosTitles(jsonObj);
            TaskSolver.PrintTitles(titles);
            
            var videos = TaskSolver.GetVideos(jsonObj);
            var html = TaskSolver.GetHtmlString(videos);
            TaskSolver.SaveHtml(html, HtmlName);
        }
    }
}
