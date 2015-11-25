namespace Brackets
{
    using System;

    public class Brackets
    {
        public static void Main()
        {
            var expression = Console.ReadLine();
            var expressionLength = expression.Length;

            var dynamic = new long[expressionLength + 1, expressionLength + 2];
            dynamic[0, 0] = 1;

            for (var k = 1; k <= expressionLength; k++)
            {
                if (expression[k - 1] == '(')
                {
                    dynamic[k, 0] = 0;
                }
                else
                {
                    dynamic[k, 0] = dynamic[k - 1, 1];
                }

                for (var c = 1; c <= expressionLength; c++)
                {
                    switch (expression[k - 1])
                    {
                        case '(':
                            dynamic[k, c] = dynamic[k - 1, c - 1];
                            break;
                        case ')':
                            dynamic[k, c] = dynamic[k - 1, c + 1];
                            break;
                        default:
                            dynamic[k, c] = dynamic[k - 1, c - 1] + dynamic[k - 1, c + 1];
                            break;
                    }
                }
            }

            Console.WriteLine(dynamic[expressionLength, 0]);
        }
    }
}
