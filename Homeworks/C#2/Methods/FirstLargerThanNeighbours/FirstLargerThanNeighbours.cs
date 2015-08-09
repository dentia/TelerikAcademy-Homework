//Problem 6. First larger than neighbours
//Write a method that returns the index of the first 
//element in array that is larger than its neighbours, or -1, if there’s no such element.
//Use the method from the previous exercise.

namespace FirstLargerThanNeighbours
{
    using System;
    using System.Linq;
    using LargerThanNeighbours;
    class FirstLargerThanNeighbours
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integers, separated by a comma: ");
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            NumberCollection numbers = new NumberCollection(input);
            Console.WriteLine("Pos: " + FirstLargestOrDefault(numbers));
        }

        private static int FirstLargestOrDefault(NumberCollection numbers)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers.IsGreaterThanNeighbours(index))
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
