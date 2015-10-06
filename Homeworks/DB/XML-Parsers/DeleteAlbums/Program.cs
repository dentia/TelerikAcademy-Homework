using System.IO;

namespace DeleteAlbums
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            var root = doc.DocumentElement;

            DeleteAlbumsWithPrice(root, 20.0);
            doc.Save("../../updatedCatalogue.xml");

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("new catalogue saved as " + savedDir + "updatedCatalogue.xml");
        }

        private static void DeleteAlbumsWithPrice(XmlElement root, double maxPrice)
        {
            var childNodes = root.ChildNodes;

            for (int a = childNodes.Count - 1; a >= 0; a--)
            {
                var album = childNodes[a];

                var xmlPrice = album["price"].InnerText;
                var price = double.Parse(xmlPrice);

                if (price > maxPrice)
                {
                    root.RemoveChild(album);
                }
            }
        }
    }
}
