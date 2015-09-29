using System;
using System.Linq;

namespace XDocument
{
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("../../catalogue.xml");
            var albums = doc.Element("catalogue")
                .Elements("album");

            var titles = from title in albums.Descendants("title") select title.Value;

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
