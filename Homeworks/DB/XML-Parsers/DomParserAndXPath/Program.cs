namespace DomParserAndXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../catalogue.xml");
            var root = doc.DocumentElement;

            Console.WriteLine(string.Join(", ", GetUniqueArtistsWithDomParser(root)) + " - DomParser");
            Console.WriteLine(string.Join(", ", GetUniqueArtistsWithXPath(doc)) + " - XPath");
        }

        private static string[] GetUniqueArtistsWithDomParser(XmlElement root)
        {
            var uniqueArtists = new HashSet<string>();
            var artists = root.GetElementsByTagName("artist");

            foreach (XmlElement artist in artists)
            {
                uniqueArtists.Add(artist.InnerText);
            }

            return uniqueArtists.ToArray();
        }

        private static string[] GetUniqueArtistsWithXPath(XmlDocument root)
        {
            var uniqueArtists = new HashSet<string>();
            var artists = root.SelectNodes("/catalogue/album/artist");

            foreach (XmlNode artist in artists)
            {
                uniqueArtists.Add(artist.InnerText);
            }

            return uniqueArtists.ToArray();
        }
    }
}
