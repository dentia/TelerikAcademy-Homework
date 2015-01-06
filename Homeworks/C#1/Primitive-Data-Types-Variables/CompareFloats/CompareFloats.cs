//Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
//Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature 
//of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely 
//to each other than a fixed constant eps.

namespace CompareFloats
{
    using System;
    class CompareFloats
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            bool equal = Math.Abs(firstNumber - secondNumber) < 0.000001;

            Console.WriteLine("The numbers are{0}equal.", equal ? " " : " NOT ");
        }
    }
}
