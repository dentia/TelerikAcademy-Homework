//Write a program that gets two numbers from the console and prints the greater of them.
//Try to implement this without if statements.

namespace NumberComparer
{
    using System;
    class NumberComparer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers: ");
            Console.WriteLine("The greater one is " +
                Math.Max(
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())));
        }
    }
}
