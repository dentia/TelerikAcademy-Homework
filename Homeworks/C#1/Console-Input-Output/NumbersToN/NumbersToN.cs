//Write a program that reads an integer number n from the console and 
//prints all the numbers in the interval [1..n], each on a single line.
namespace NumbersToN
{
    using System;
    using System.Linq;
    class NumbersToN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if(number<1)
                for (int numbers = 1; numbers >= number; numbers--)
                    Console.WriteLine(numbers);
            else
                for (int numbers = 1; numbers <= number; numbers++)
                    Console.WriteLine(numbers);
        }
    }
}
