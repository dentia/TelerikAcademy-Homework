//Write a program that replaces in a HTML document given as string 
//all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

namespace ReplaceTags
{
    using System;
    using System.Text.RegularExpressions;
    class ReplaceTags
    {
        static void Main(string[] args)
        {
            string line = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <	 a 	 href	=	\"www.devbg.org\">our forum<		/	a    > to discuss the courses.</p>";
            line = ReplaceOpeningTags(line);
            line = ReplaceClosingTags(line);
            Console.Clear();
            Console.WriteLine(line);
        }

        private static string ReplaceOpeningTags(string text)
        {
            return Regex.Replace(text, @"<\s*a\s*href\s*=.*?>", delegate(Match match)
            {
                string current = match.ToString();
                Console.WriteLine(current);
                current = Regex.Replace(current, @"<\s*", "[");
                current = Regex.Replace(current, @"\s*=\s*", "=");
                current = Regex.Replace(current, @"\s*>", "]");
                current = current.Replace("\"", String.Empty);
                return Regex.Replace(current, @"(a\s*href\s*)", "URL");
            });
        }

        private static string ReplaceClosingTags(string text)
        {
            return Regex.Replace(text, @"(\<\s*\/\s*a\s*\>)", delegate(Match match)
            {
                string current = match.ToString();
                return "[/URL]";
            });
        }
    }
}
