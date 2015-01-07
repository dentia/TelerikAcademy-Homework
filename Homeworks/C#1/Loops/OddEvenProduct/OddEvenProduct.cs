//You are given n integers (given in a single line, separated by a space).
//Write a program that checks whether the product of the odd 
//elements is equal to the product of the even elements.
//Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
namespace OddEvenProduct
{
    using System;
    using System.Linq;
    class OddEvenProduct
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by space: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            long oddProduct = 1;
            long evenProduct = 1;

            for (int index = 0; index < numbers.Length; index++)
            {
                if (index % 2 == 0)
                    oddProduct *= numbers[index];

                else evenProduct *= numbers[index];
            }

            PrintResult(oddProduct, evenProduct);
        }

        private static void PrintResult(long oddProduct, long evenProduct)
        {
            if (oddProduct == evenProduct)
            {
                Console.WriteLine("yes");
                Console.WriteLine("product = " + oddProduct);
            }
            else
            {
                Console.WriteLine("no");
                Console.WriteLine("odd_product = " + oddProduct);
                Console.WriteLine("even_product = " + evenProduct);
            }
        }
    }
}
