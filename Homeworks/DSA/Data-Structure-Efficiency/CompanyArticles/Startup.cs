namespace CompanyArticles
{
    using System;

    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main()
        {
            var articles = new OrderedMultiDictionary<decimal, Article>(false);

            for (int i = 0; i < 1000; i++)
            {
                var article = new Article(i.ToString(), "Vendor N#" + i, i);
                article.Barcode = article.GetHashCode().ToString();

                articles.Add(article.Price, article);
            }

            var articlesInRange = articles.Range(200, true, 250, true).Values;
            Console.WriteLine(articlesInRange);
        }
    }
}
