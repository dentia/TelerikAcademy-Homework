//Create a console application that calculates and prints the square root of the number 12345.

namespace SquareRoot
{
    using System;
    class SquareRoot
    {
        const int NUMBER = 12345;
        static void Main(string[] args)
        {
            System.Console.WriteLine(Math.Sqrt(NUMBER));
        }
    }
}
