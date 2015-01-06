//Write a program to read your birthday from the console and 
//print how old you are now and how old you will be after 10 years.

namespace AgeAfterTenYears
{
    using System;
    using System.Linq;
    class AgeAfterTenYears
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your birthday in format: dd/MM/yyyy: ");

            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', '/', ',', '-', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string format = "dd/MM/yyyy";

            DateTime birthDate = DateTime.ParseExact(
                string.Join("/", input), 
                format, 
                System.Globalization.CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.AddYears(-age) < birthDate) --age;

            Console.WriteLine("At this date, after ten years you'll be {0} y.o.", age + 10);
        }
    }
}
