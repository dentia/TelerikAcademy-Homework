//Implement a set of extension methods for IEnumerable<T> that implement 
//the following group functions: sum, product, min, max, average.

namespace TestIEnumerable
{
    using System;
    using System.Collections.Generic;
    using ExtensionMethods;
    class TestIEnumerable
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            Console.WriteLine(String.Join(", ", numbers));
            Console.WriteLine("Min:\t{0}", numbers.Min());
            Console.WriteLine("Max:\t{0}", numbers.Max());
            Console.WriteLine("Sum:\t{0}", numbers.Sum());
            Console.WriteLine("Avg:\t{0}", numbers.Average());
            Console.WriteLine("Prod:\t{0}", numbers.Product());
        }
    }
}
