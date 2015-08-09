
namespace SolveTasks
{
    using System;
    using Converter;
    class SolveTasks
    {
        static void Main(string[] args)
        {
            Converter converter = new Converter();

            // Write a program to convert decimal numbers to their binary representation
            Console.WriteLine(converter.DecimalToBinary(254u));

            // Write a program to convert binary numbers to their decimal representation
            Console.WriteLine(converter.BinaryToDecimal("11111110"));

            // Write a program to convert decimal numbers to their hexadecimal representation
            Console.WriteLine(converter.DecimalToHex(254u));

            // Write a program to convert hexadecimal numbers to their decimal representation
            Console.WriteLine(converter.HexToDecimal("FE"));

            // Write a program to convert hexadecimal numbers to binary numbers
            Console.WriteLine(converter.HexToBinary("FE"));

            // Write a program to convert binary numbers to hexadecimal numbers
            Console.WriteLine(converter.BinaryToHex("11111110"));

            // Write a program to convert from any numeral system of given 
            // base s to any other numeral system of base d (2 ≤ s, d ≤ 16)
            Console.WriteLine(converter.Convert("254", 10, 3));
            Console.WriteLine(converter.Convert("100102", 3, 10));

            // Write a program that shows the binary representation of given 
            // 16-bit signed integer number (the C# type short)
            Console.WriteLine(converter.ShortToBinary(254));

            //Write a program that shows the internal binary representation of 
            // given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
            string[] result = converter.FloatToBinary(-27.25f);
            Console.WriteLine("SIGN:        " + result[0]);
            Console.WriteLine("EXPONENT:    " + result[1]);
            Console.WriteLine("MANTISSA:    " + result[2]);
        }
    }
}
