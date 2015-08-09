//Write a program that prints to the console which day of the week is today.
//Use System.DateTime.

namespace DayOfWeek
{
    using System;
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("dddd"));
        }
    }
}
