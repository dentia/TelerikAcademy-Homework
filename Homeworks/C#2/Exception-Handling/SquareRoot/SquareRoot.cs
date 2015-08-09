//Write a program that reads an integer number and calculates and prints its square root.
//If the number is invalid or negative, print Invalid number.
//In all cases finally print Good bye.
//Use try-catch-finally block.

namespace SquareRoot
{
    using System;
    class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a positive number: ");
                double number = double.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}

