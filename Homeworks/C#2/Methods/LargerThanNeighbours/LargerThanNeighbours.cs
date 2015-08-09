//Write a method that checks if the element at given position 
//in given array of integers is larger than its two neighbours (when such exist).

namespace LargerThanNeighbours
{
    using System;
    using System.Linq;
    class LargerThanNeighbours
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers, separated by a comma: ");
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.Write("Enter position: ");
            int position = int.Parse(Console.ReadLine());

            NumberCollection numbers = new NumberCollection(input);
            Console.WriteLine(numbers.IsGreaterThanNeighbours(position));
        }
    }
}
