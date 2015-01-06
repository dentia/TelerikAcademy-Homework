//Write an expression that checks for given integer if its third digit from right-to-left is 7.

namespace ThirdDigitIs7
{
    using System;
    class ThirdDigitIs7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number to check: ");
            int number = int.Parse(Console.ReadLine());
            if (number < 100)
            {
                Console.WriteLine("The number must have at least 3 digits.");
                return;
            }


            Console.WriteLine("The third digit (right to left) {0} seven.", ThirdDigitIsSeven(number) ? "IS" : "IS NOT");
        }

        static bool ThirdDigitIsSeven(int number)
        {
            if (number < 100) throw new ArgumentException("The number should have at least 3 digits.");
            if ((number / 100) % 10 != 7) return false;
            return true;
        }
    }
}
