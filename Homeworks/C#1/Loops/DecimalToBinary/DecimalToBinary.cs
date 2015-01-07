//Using loops write a program that converts an integer number to its binary representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.

namespace DecimalToBinary
{
    using System;
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("The number must be positive.");
                return;
            }

            Console.WriteLine("{0} -> {1}", number, ToBinary(number));
        }
        public static string ToBinary(int number)
        {
            if (number == 0) return number.ToString();

            string binary = String.Empty;
            int result = number;
            while (result > 0)
            {
                binary += (result % 2).ToString();
                result /= 2;
            }
            return ReverseString(binary);
        }
        public static string ReverseString(string binary)
        {
            var temp = binary.ToCharArray();
            Array.Reverse(temp);
            return new String(temp);
        }
    }
}
