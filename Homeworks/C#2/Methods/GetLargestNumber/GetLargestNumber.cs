//Write a method GetMax() with two parameters that returns the larger of two integers.
//Write a program that reads 3 integers from the 
//console and prints the largest of them using the method GetMax().

namespace GetLargestNumber
{
    using System;
    class GetLargestNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            for (int count = 0; count < numbers.Length; count++)
            {
                Console.Write("Enter number {0}: ", count + 1);
                numbers[count] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(GetMax(GetMax(numbers[0], numbers[1]), numbers[2]));
        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            return (firstNumber > secondNumber) ? 
                firstNumber : secondNumber;
        }
    }
}
