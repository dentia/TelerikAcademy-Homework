// Write a program that reads a number N and generates 
//and prints all the permutations of the numbers [1 … N]. Example:
//n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

namespace Permutation
{
    using System;
    using System.Linq;
    class Permutation
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int range = int.Parse(Console.ReadLine());

            Combinatorics.Permutation permutationGenerator = 
                new Combinatorics.Permutation(range);
            Console.WriteLine(permutationGenerator.GetAllPermutations());
        }
    }
}
