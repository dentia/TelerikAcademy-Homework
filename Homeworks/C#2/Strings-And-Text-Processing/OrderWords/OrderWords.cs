//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order

namespace OrderWords
{
    using System;
    using System.Linq;
    class OrderWords
    {
        static void Main(string[] args)
        {
//Nulla vel magna sit amet dui lobortis commodo vitae nulla amet ante hendrerit tempus Cras molestie risus a enim convallis vitae luctus libero lacinia Suspendisse potenti Donec et nisi dictum felis sollicitudin congue Duis sagittis est amet gravida
            Console.Write("Enter some words, separated by a space: ");
            var words = Console.ReadLine()
                .ToUpperInvariant()
                .Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            words = words
                .Distinct()
                .ToList();

            words = words.OrderBy(x => x).ToList();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
