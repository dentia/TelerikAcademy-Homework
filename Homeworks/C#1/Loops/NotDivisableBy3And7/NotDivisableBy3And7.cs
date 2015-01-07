//Write a program that enters from the console a positive integer n 
//and prints all the numbers from 1 to n not divisible by 3 and 7, 
//on a single line, separated by a space.
namespace NotDivisableBy3And7
{
    using System;
    using System.Text;
    class NotDivisableBy3And7
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a number: ");
            int range = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            if (range < 1)
            {
                for (int number = 1; number >= range; number--)
                {
                    if (!(number % 3 == 0 || number % 7 == 0))
                        result.Append(number + " ");
                }
            }


            else
            {
                for (int number = 1; number <= range; number++)
                {
                    if (!(number % 3 == 0 || number % 7 == 0))
                        result.Append(number + " ");
                }
            }

            Console.WriteLine(result);
        }
    }
}
