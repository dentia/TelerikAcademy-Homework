//Write a program to check if in a given expression the brackets are put correctly.

namespace CorrectBrackets
{
    using System;
    class CorrectBrackets
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an expression: ");
            string expression = Console.ReadLine();

            Console.WriteLine(BracketsAreCorrect(expression) ? "CORRECT" : "INCORRECT");
        }

        private static bool BracketsAreCorrect(string expression)
        {
            int bracketCount = 0;

            foreach (var letter in expression)
            {
                if (letter == '(')
                    ++bracketCount;
                else if (letter == ')')
                    --bracketCount;

                if (bracketCount < 0)
                    return false;
            }

            return bracketCount == 0;
        }
    }
}
