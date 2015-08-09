//Write a program that reads two numbers N and K and generates 
//all the combinations of K distinct elements from the set [1..N]. Example:
//N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

namespace Combination
{
    using System;
    class Combination
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int range = int.Parse(Console.ReadLine());
            Console.Write("Enter combination lenght: ");
            int lenght = int.Parse(Console.ReadLine());

            Combinatorics.Combination combinationGenerator = 
                new Combinatorics.Combination(lenght);
            Console.WriteLine(combinationGenerator.GetAllCombinations(range));
        }
    }
}
