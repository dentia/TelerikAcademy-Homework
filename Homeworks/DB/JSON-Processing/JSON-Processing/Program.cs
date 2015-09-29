namespace JSON_Processing
{
    using System;
    using System.Text;

    class Program
    {
        private const string RssLink = "http://www.dnevnik.bg/rss/?page=index";
        private const string XmlPath = "news.xml";
        private const string HtmlName = "index.html";

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var taskSolver = new TaskSolver();

            taskSolver.DownloadRss(RssLink);
            var xmlDoc = taskSolver.GetXml(XmlPath);
            var jsonObj = taskSolver.GetJsonObject(xmlDoc);
            var titles = taskSolver.GetNewsTitles(jsonObj);
            taskSolver.PrintTitles(titles);
            
            var news = taskSolver.GetNews(jsonObj);
            var html = taskSolver.GetHtmlString(news);
            taskSolver.SaveHtml(html, HtmlName);
        }
    }
}
