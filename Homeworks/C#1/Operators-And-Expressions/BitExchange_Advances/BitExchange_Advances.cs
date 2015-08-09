//Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.

namespace BitExchange_Advances
{
    using System;
    class BitExchange_Advances
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            uint number = uint.Parse(Console.ReadLine());
            Console.Write("Enter position P: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter position Q: ");
            int q = int.Parse(Console.ReadLine());
            Console.Write("Enter step K: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

            if (p > q)
            {
                int temp = q;
                q = p;
                p = temp;
            }

            if (InputIsCorrect(p, q, k))
            {

                uint mask = ((number >> p) ^ (number >> q)) & ((1u << k) - 1);
                uint result = number ^ ((mask << p) | (mask << q));

                Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
                Console.WriteLine(result);
            }

            //Main(new string[] { });
        }

        private static bool InputIsCorrect(int p, int q, int k)
        {
            if ((p < 0 || p > 32) || (q < 0 || q > 32))
            {
                Console.WriteLine("out of range");
                return false;
            }
            if (p + k >= q)
            {
                Console.WriteLine("overlapping");
                return false;
            }
            if (q + k > 32)
            {
                Console.WriteLine("out of range");
                return false;
            }
            return true;
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