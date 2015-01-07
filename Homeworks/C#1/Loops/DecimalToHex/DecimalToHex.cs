//Using loops write a program that converts an integer number to its hexadecimal representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.

namespace DecimalToHex
{
    using System;
    class DecimalToHex
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("The number must be positive.");
                return;
            }

            Console.WriteLine("{0} -> {1}", number, ToHex(number));
        }
        public static string ToHex(int number)
        {
            string hex = string.Empty;
            if (number == 0) return number.ToString();

            while (number > 0)
            {
                hex += DigitInHex(number % 16);
                number /= 16;
            }

            return ReverseString(hex);
        }

        public static string ReverseString(string binary)
        {
            var temp = binary.ToCharArray();
            Array.Reverse(temp);
            return new String(temp);
        }

        public static string DigitInHex(int number)
        {
            switch (number)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return number.ToString();
                case 10: return "A";
                case 11: return "B";
                case 12: return "C";
                case 13: return "D";
                case 14: return "E";
                case 15: return "F";
                default: return String.Empty;
            }
        }
    }
}
