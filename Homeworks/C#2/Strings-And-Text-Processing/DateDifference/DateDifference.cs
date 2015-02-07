//Write a program that reads two dates in the format: 
//day.month.year and calculates the number of days between them.

namespace DateDifference
{
    using System;
    using System.Globalization;
    class DateDifference
    {
        static void Main(string[] args)
        {
            string format  = "d.M.yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            Console.Write("Enter the first date: ");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), format, provider);
            Console.Write("Enter the second date: ");
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), format, provider);

            if (startDate > endDate)
            {
                SwapDates(ref startDate, ref endDate);
            }

            Console.WriteLine("Distance: " + (endDate - startDate).TotalDays);
        }

        private static void SwapDates(ref DateTime start, ref DateTime end)
        {
            DateTime temp = start;
            start = end;
            end = temp;
        }
    }
}
