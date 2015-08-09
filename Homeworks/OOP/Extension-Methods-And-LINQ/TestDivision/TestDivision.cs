//Write a program that prints from given array of integers 
//all numbers that are divisible by 7 and 3. 
//Use the built-in extension methods and lambda expressions. 
//Rewrite the same with LINQ.
namespace TestDivision
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class TestDivision
    {
        static void Main(string[] args)
        {
            int[] numbers = new[] { 21, 42, 3, 7, 1, 2, 4, 6, 7, 9, 11, 13, 23 };
            Console.WriteLine(String.Join(", ", numbers.NumbersDivisableBy_Lambda(3, 7)));
            Console.WriteLine(String.Join(", ", numbers.NumbersDivisableBy_Linq(3, 7)));
        }

        private static IEnumerable<int> NumbersDivisableBy_Linq(
            this IEnumerable<int> numbers, int divider1, int divider2)
        {
            return from num in numbers
                   where (num % divider1 == 0 || num % divider2 == 0)
                   select num;
                   
        }

        private static IEnumerable<int> NumbersDivisableBy_Lambda(
            this IEnumerable<int> numbers, int divider1, int divider2)
        {
            return numbers
                .Where(x => x % divider1 == 0 || x % divider2 == 0);
        }
    }
}
