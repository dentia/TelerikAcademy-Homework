namespace Exam_EncodingSum
{
    using System;

    public class EncodingSum
    {
        private const char EndCharacter = '@';

        public static void Main()
        {
            int module = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            long result = GetEncodedValue(input, module);

            Console.WriteLine(result);
        }

        public static long GetEncodedValue(string input, int module)
        {
            long result = 0;
            int index = 0;

            while (true)
            {
                char current = input[index];
                if (current == EndCharacter)
                {
                    return result;
                }
                else if (char.IsDigit(current))
                {
                    result *= GetDigitValue(current);
                }
                else if (char.IsLetter(current))
                {
                    result += GetLetterValue(current);
                }
                else
                {
                    result %= module;
                }
                ++index;
            }
        }

        private static int GetDigitValue(char symbol)
        {
            return symbol - '0';
        }

        private static int GetLetterValue(char symbol)
        {
            return char.ToUpper(symbol) - 'A';
        }
    }
}
