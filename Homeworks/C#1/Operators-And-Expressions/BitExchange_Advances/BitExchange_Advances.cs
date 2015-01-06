//Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.

namespace BitExchange_Advances
{
    using System;
    class BitExchange_Advances
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            long number = long.Parse(Console.ReadLine());
            Console.Write("Enter position P: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter position Q: ");
            int q = int.Parse(Console.ReadLine());
            Console.Write("Enter step K: ");
            int k = int.Parse(Console.ReadLine());

            for (int i = p, j = q, l = k; (i <= 32 && j <= 32) && l > 0; i++, j++, l--)
            {
                if (((number >> i) & 1) != ((number >> j) & 1))
                {
                    number = changeBits(number, i, j);
                }
            }
            Console.WriteLine("Result: " + number);
        }

        private static long changeBits(long number, int firstposition, int secondPosition)
        {
            number ^= (1 << firstposition);
            return number ^ (1 << secondPosition);
        }
    }
}

/*
 for ex.
 * 
 * 111 in binary is 1101111
 * if p=3, q=10, k=3, we exchange 3 with 10, 4 with 11 and 5 with 12
 * we get 1010001000111 or 5191 in dec
 * 
 * 
 * |12|11|10|09|08|07|06|05|04|03|02|01|00|
 * ----------------------------------------
 * | 0| 0| 0| 0| 0| 0| 1| 1| 0| 1| 1| 1| 1|
 * | 1| 0| 1| 0| 0| 0| 1| 0| 0| 0| 1| 1| 1|
 */