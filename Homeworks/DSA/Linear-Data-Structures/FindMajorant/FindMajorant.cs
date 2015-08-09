// The majorant of an array of size N is a value that
// occurs in it at least N/2 + 1 times. Write a program to
// find the majorant of given array (if exists).

namespace FindMajorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    class FindMajorant
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers on separate lines. The sequence should end with an empty line.");
            List<int> numbers = Common.ReadInput();

            try
            {
                Console.WriteLine("Majorant: {0}", numbers.First(x => numbers.Count(y => y == x) > numbers.Count / 2));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The sequence does not contain a majorant.");
            }
        }
    }
}
