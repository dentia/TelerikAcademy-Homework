//Create a console application that prints the current date and time. Find out how in Internet.

namespace CurrentDateAndTime
{
    using System;
    class CurrentDateAndTime
    {
        static void Main(string[] args)
        {
            DateTime current = DateTime.Now;
            Console.WriteLine(current);
        }
    }
}
