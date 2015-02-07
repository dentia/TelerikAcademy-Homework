//Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100

namespace EnterNumbers
{
    using System;
    class EnterNumbers
    {
        static int MIN = 1;
        static int MAX = 100;
        const int COUNT = 10;
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < COUNT; i++)
                {
                    MIN = ReadInteger();
                }
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

        private static int ReadInteger()
        {
            Console.Write("Enter number in range [{0}...{1}]: ", MIN + 1, MAX - 1);
            int number = int.Parse(Console.ReadLine());

            if (number <= MIN || number >= MAX)
            {
                throw new ArgumentOutOfRangeException();
            }

            return number;
        }
    }
}
