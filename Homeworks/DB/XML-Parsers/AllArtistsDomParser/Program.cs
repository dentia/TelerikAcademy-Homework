namespace AllArtistsDomParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../catalogue.xml");
            var root = doc.DocumentElement;

            foreach (var pair in GetUniqueArtists(root))
            {
                Console.WriteLine("{0} - {1} album(s)", pair.Key, pair.Value);
            }
        }

        private static Dictionary<string, int> GetUniqueArtists(XmlElement root)
        {
            var artistsAndAlbums = new Dictionary<string, int>();
            var artists = root.GetElementsByTagName("artist");

            foreach (XmlElement artist in artists)
            {
                var artistName = artist.InnerText;

                if (artistsAndAlbums.ContainsKey(artistName))
                {
                    artistsAndAlbums[artistName] += 1;
                }
                else
                {
                    artistsAndAlbums.Add(artistName, 1);
                }
            }

            return artistsAndAlbums;
        }
    }
}
