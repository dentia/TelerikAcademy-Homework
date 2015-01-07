//Using loops write a program that converts a binary integer number to its decimal form.
//The input is entered as string. The output should be a variable of type long.
//Do not use the built-in .NET functionality.

namespace BinaryToDecimal
{
    using System;
    class BinaryToDecimal
    {
        static void Main(string[] args)
        {
            Console.Write("Enter binary number: ");
            string binary = Console.ReadLine().Trim();

            Console.WriteLine("Traditional way: " + ConvertToDecimal(binary));
            Console.WriteLine("Horner Scheme: " + HornerScheme(binary));
        }

        public static int ConvertToDecimal(string binary)
        {
            int decimalNumber = 0;

            for (int bit = binary.Length - 1, pow = 0; bit >= 0; bit--, pow++)
            {
                decimalNumber += int.Parse(binary[bit].ToString()) * (int)Math.Pow(2, pow);
            }
            return decimalNumber;
        }

        public static int HornerScheme(string binary)
        {
            int result = 0;
            for (int bit = 0; bit < binary.Length; bit++)
            {
                result *= 2;
                result += int.Parse(binary[bit].ToString());
            }
            return result;
        }
    }
}
