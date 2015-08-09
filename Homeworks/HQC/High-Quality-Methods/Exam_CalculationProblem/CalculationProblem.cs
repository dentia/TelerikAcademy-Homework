namespace Exam_CalculationProblem
{
    using System;
    using System.Text;

    internal class CalculationProblem
    {
        private const uint NumeralBase = 23;

        internal static void Main()
        {
            string[] input = GetInput();
            uint sum = CalculateSum(input);
            string result = GetStringValue(sum);

            Console.WriteLine("{0} = {1}", result, sum);
        }

        private static uint CalculateSum(string[] input)
        {
            uint result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                result += GetNumericValue(input[i]);
            }

            return result;
        }

        private static string[] GetInput()
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return input;
        }

        private static string GetStringValue(uint number)
        {
            StringBuilder result = new StringBuilder();

            do
            {
                result.Insert(0, (char)((number % NumeralBase) + 'a'));
                number /= NumeralBase;
            } 
            while (number > 0);

            return result.ToString();
        }

        private static uint GetNumericValue(string number)
        {
            uint result = 0;
            for (int i = 0; i < number.Length; i++)
            {
                result *= NumeralBase;
                result += (uint)(number[i] - 'a');
            }

            return result;
        }
    }
}