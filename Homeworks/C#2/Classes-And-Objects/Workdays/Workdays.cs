//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday 
//except a fixed list of public holidays specified preliminary as array.

namespace Workdays
{
    using System;
    using System.Collections.Generic;
    class Workdays
    {
        static List<DateTime> publicHolydays;
        static void Main(string[] args)
        {
            publicHolydays = new List<DateTime>()
            {new DateTime(2015, 3, 1),new DateTime(2015, 3, 3),new DateTime(2015, 4, 2),
            new DateTime(2015, 4, 10), new DateTime(2015, 5, 2),new DateTime(2015, 5, 12),
            new DateTime(2015, 5, 16),new DateTime(2015, 6, 13),new DateTime(2015, 6, 15)};

            Console.WriteLine(CountWorkdays(new DateTime(2015, 1, 1), new DateTime(2015, 6, 20)));
        }

        private static string CountWorkdays(DateTime startDate, DateTime endDate)
        {
            int workDays = 0;
            int holydays = 0;
            int weekends = 0;
            DateTime current = startDate;

            while (current <= endDate)
            {
                if (publicHolydays.Contains(current))
                    ++holydays;
                else if ((int)current.DayOfWeek == 0 || (int)current.DayOfWeek == 6)
                    ++weekends;
                else
                    ++workDays;

                current = current.AddDays(1);
            }

            return String.Format(@"
Holydays:   {0}
Weekends:   {1}
Workdays:   {2}
", holydays, weekends, workDays);
        }
    }
}
