namespace NewAlbumsLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("../../catalogue.xml");

            var albumNames = from album in doc.Descendants("album")
                where int.Parse(album.Element("year").Value) > 1996
                select album.Element("name").Value;

            Console.WriteLine(string.Join(Environment.NewLine, albumNames));
        }
    }
}
