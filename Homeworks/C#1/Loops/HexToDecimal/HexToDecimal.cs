//Using loops write a program that converts a hexadecimal integer number to its decimal form.
//The input is entered as string. The output should be a variable of type long.
//Do not use the built-in .NET functionality.
namespace HexToDecimal
{
    using System;
    class HexToDecimal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hexadecimal number: ");
            string hex = Console.ReadLine().Trim().ToUpper();

            Console.WriteLine("{0} -> {1}", hex, ToDecimal(hex));
        }

        public static int ToDecimal(string hex)
        {
            int decimalNumber = 0;

            for (int digit = hex.Length - 1, pow = 0; digit >= 0; digit--, pow++)
            {
                decimalNumber += HexToDigit(hex[digit]) * (int)Math.Pow(16, pow);
            }
            return decimalNumber;
        }

        private static int HexToDigit(char digit)
        {
            switch (digit)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return int.Parse(digit.ToString());
                case 'A': return 10;
                case 'B': return 11;
                case 'C': return 12;
                case 'D': return 13;
                case 'E': return 14;
                case 'F': return 15;
                default: return 0;
            }
        }
    }
}
