//Write a Boolean expression that returns if the bit 
//at position p (counting from 0, starting from the right) in given integer number n, has value of 1.
namespace CheckBit
{
    using System;
    class CheckBit
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter position to check bit: ");
            int position = int.Parse(Console.ReadLine());

            Console.WriteLine("Bit is one: " + BitIsOne(number, position));
        }

        private static bool BitIsOne(int number, int position)
        {
            if ((number & (1 << position)) == 0) return false;
            return true;
        }
    }
}
