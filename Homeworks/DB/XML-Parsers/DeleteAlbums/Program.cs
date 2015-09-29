namespace DeleteAlbums
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../catalogue.xml");
            var root = doc.DocumentElement;

            DeleteAlbumsWithPrice(root, 20.0);
            doc.Save("../../updatedCatalogue.xml");
            Console.WriteLine("new catalogue saved as updatedCatalogue.xml");
        }

        private static void DeleteAlbumsWithPrice(XmlElement root, double maxPrice)
        {
            foreach (XmlElement album in root.ChildNodes)
            {
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
