//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.

namespace DatesFromTextInCanada
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;
    class DatesFromTextInCanada
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

            string text = "02.10.2015 03.5.2015 2.1.2015 2.10.2015";

            string format = "d.M.yyyy";
            CultureInfo provider = Thread.CurrentThread.CurrentCulture;

            foreach (var match in Regex.Matches(text, @"[\d]{1,2}.[\d]{1,2}.[\d]{4}"))
            {
                try
                {
                    DateTime check = DateTime.ParseExact(match.ToString(), format, provider);
                    Console.WriteLine(check.ToShortDateString());
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
    }
}
