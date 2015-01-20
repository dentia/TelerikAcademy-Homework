//Write a program that reads two numbers N and K and 
//generates all the variations of K elements from the set [1..N]. Example:
//N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

namespace Variation
{
    using System;
    class Variation
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int range = int.Parse(Console.ReadLine());
            Console.Write("Enter variation lenght: ");
            int lenght = int.Parse(Console.ReadLine());

            Combinatorics.Variation variationGenerator = 
                new Combinatorics.Variation(lenght);
            Console.WriteLine(variationGenerator.GetAllVariations(range));
        }
    }
}
