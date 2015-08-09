namespace Exam_SequenceOfBits
{
    using System;
    using System.Text;

    public class SequenceOfBits
    {
        private const int LastBitsCount = 30;

        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int[] numbers = GetInputNumbers(count);
            string bits = GetBitsString(numbers);
            var bitsCount = GetBitsCount(bits);

            Console.WriteLine("{0}{1}{2}", bitsCount.Item1, Environment.NewLine, bitsCount.Item2);
        }

        private static int[] GetInputNumbers(int count)
        {
            int[] numbers = new int[count];

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            return numbers;
        }

        private static string GetBitsString(int[] numbers)
        {
            StringBuilder bits = new StringBuilder();

            for (int currentNumber = 0; currentNumber < numbers.Length; currentNumber++)
            {
                for (int bit = 0; bit < LastBitsCount; bit++)
                {
                    bits.Insert(0, (numbers[currentNumber] >> bit) & 1);
                }
            }

            return bits.ToString();
        }

        private static Tuple<long, long> GetBitsCount(string bits)
        {
            long countZeros = 0;
            long tempZeros = 0;
            long countOnes = 0;
            long tempOnes = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                {
                    tempZeros++;
                    tempOnes = 0;
                }
                else
                {
                    ++tempOnes;
                    tempZeros = 0;
                }

                if (tempZeros > countZeros)
                {
                    countZeros = tempZeros;
                }

                if (tempOnes > countOnes)
                {
                    countOnes = tempOnes;
                }
            }

            return new Tuple<long, long>(countOnes, countZeros);
        }
    }
}
