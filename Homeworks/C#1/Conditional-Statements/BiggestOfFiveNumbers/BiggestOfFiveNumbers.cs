//Write a program that finds the biggest of five numbers by using only five if statements.

namespace BiggestOfFiveNumbers
{
    using System;
    using System.Linq;
    class BiggestOfFiveNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter five numbers: ");
            double[] numbers = new double[5];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }


            Console.WriteLine("Math.Max: " + MaxWithoutIf(numbers));

            Console.WriteLine("IFs: " + MaxWithIf(numbers));
            

        }

        private static string MaxWithIf(double[] numbers)
        {
            if (numbers[0] == numbers.Max())
            {
                return numbers[0].ToString();
            }
            if (numbers[1] == numbers.Max())
            {
                return numbers[1].ToString();
            }
            if (numbers[2] == numbers.Max())
            {
                return numbers[2].ToString();
            }
            if (numbers[3] == numbers.Max())
            {
                return numbers[3].ToString();
            }
            if (numbers[4] == numbers.Max())
            {
                return numbers[4].ToString();
            }

            return string.Empty;
        }

        private static string MaxWithoutIf(double[] numbers)
        {
            double max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                max = Math.Max(max, numbers[i]);
            }

            return max.ToString();
        }
    }
}
