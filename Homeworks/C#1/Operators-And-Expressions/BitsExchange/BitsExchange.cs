//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
namespace BitsExchange
{
    using System;
    class BitsExchange
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            uint number = uint.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

            for (int i = 3, j = 24; i < 6; i++, j++)
            {
                if (((number >> i) & 1) != ((number >> j) & 1))
                {
                    number = ChangeBits(number, i, j);
                }
            }

            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine(number);

            //Main(new string[] { });
        }

        private static uint ChangeBits(uint number, int firstposition, int secondPosition)
        {
            number ^= (1u << firstposition);
            return number ^ (1u << secondPosition);
        }
    }
}
