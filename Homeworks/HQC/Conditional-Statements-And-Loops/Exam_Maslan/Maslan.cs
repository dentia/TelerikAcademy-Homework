namespace Exam_Maslan
{
    using System;
    using System.Numerics;
    using System.Text;

    public class Maslan
    {
        private const int MaxTransformationsCount = 10;
        private const int DesiredSumLength = 1;

        public static void Main()
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            Console.WriteLine(GetTransformationResult(input));
        }

        private static string GetTransformationResult(StringBuilder input)
        {
            int transformations = 0;

            while (true)
            {
                ++transformations;
                string sum = GetSecretSum(input);

                if (sum.Length == DesiredSumLength)
                {
                    return string.Format("{0}{1}{2}", transformations, Environment.NewLine, sum);
                }
                else if (transformations == MaxTransformationsCount)
                {
                    return sum.ToString();
                }
                else
                {
                    input = new StringBuilder(sum);
                }
            }
        }

        private static string GetSecretSum(StringBuilder input)
        {
            BigInteger currentSum = 1;

            while (input.Length > 0)
            {
                input = input.Remove(input.Length - 1, 1);

                BigInteger tempSum = 0;
                for (int index = 1; index < input.Length; index += 2)
                {
                    // Char.GetNumericValue() returns double, which is not compatible
                    // with BigInteger, so we need to explicitly convert the value to int 
                    tempSum += (int)char.GetNumericValue(input[index]);
                }

                if (tempSum > 0)
                {
                    currentSum *= tempSum;
                }
            }

            return currentSum.ToString();
        }
    }
}