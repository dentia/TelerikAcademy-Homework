//Write a method that adds two positive integer numbers represented 
//as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

namespace NumbersAsArray
{
    using System;
    using System.Linq;
    class NumbersAsArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            BigNumber first = new BigNumber(Console.ReadLine());
            Console.Write("Enter the second number: ");
            BigNumber second = new BigNumber(Console.ReadLine());

            Console.WriteLine(first + second);
        }
    }
}
