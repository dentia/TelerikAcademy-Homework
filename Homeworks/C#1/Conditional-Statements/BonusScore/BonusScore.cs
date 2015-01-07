//Write a program that applies bonus score to given score in the range [1…9] by the following rules:
//If the score is between 1 and 3, the program multiplies it by 10.
//If the score is between 4 and 6, the program multiplies it by 100.
//If the score is between 7 and 9, the program multiplies it by 1000.
//If the score is 0 or more than 9, the program prints “invalid score”.

namespace BonusScore
{
    using System;
    class BonusScore
    {
        static void Main(string[] args)
        {
            Console.Write("Enter score: ");
            int score = int.Parse(Console.ReadLine());

            Console.WriteLine(GetResult(score));
        }

        private static string GetResult(int score)
        {
            switch (score)
            {
                case 1:
                case 2:
                case 3:
                    return (score * 10).ToString();
                case 4:
                case 5:
                case 6:
                    return (score * 100).ToString();
                case 7:
                case 8:
                case 9:
                    return (score * 1000).ToString();
                default:
                    return "Invalid score.";
            }
        }
    }
}
