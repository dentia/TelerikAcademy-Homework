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

            var taskSolver = new TaskSolver();

            taskSolver.DownloadRss(RssLink, XmlPath);
            var xmlDoc = taskSolver.GetXml(XmlPath);
            var jsonObj = taskSolver.GetJsonObject(xmlDoc);
            var titles = taskSolver.GetVideosTitles(jsonObj);
            taskSolver.PrintTitles(titles);
            
            var videos = taskSolver.GetVideos(jsonObj);
            var html = taskSolver.GetHtmlString(videos);
            taskSolver.SaveHtml(html, HtmlName);
        }
    }
}
