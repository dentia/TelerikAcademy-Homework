//Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##).
//Use Windows Calculator to find its hexadecimal representation.
//Print the variable and ensure that the result is 254.

namespace VariableInHexadecimalFormat
{
    using System;
    class VariableInHexadecimalFormat
    {
        static void Main(string[] args)
        {
            int number = 0xFE;
            Console.WriteLine((number == 254) ? true : false);
            Console.WriteLine(number);
        }
    }
}
