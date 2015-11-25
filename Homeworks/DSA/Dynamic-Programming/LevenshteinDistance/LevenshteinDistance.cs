namespace LevenshteinDistance
{
    using System;

    public class LevenshteinDistance
    {
        private const double Tolerance = 0.00000001;
        private const double CostDelete = 0.9;
        private const double CostInsert = 0.8;

        private static readonly string FirstWord = "_developer";
        private static readonly string SecondWord = "_enveloped";
        private static readonly int FirstWordLength = FirstWord.Length - 1;
        private static readonly int SecondWordLength = SecondWord.Length - 1;

        private static readonly double[,] F = new double[FirstWordLength + 1, SecondWordLength + 1];

        internal static void Main()
        {
            Console.WriteLine("{0} -> {1}", FirstWord.TrimStart('_'), SecondWord.TrimStart('_'));
            Console.WriteLine("Min dist: {0}", EditDistance());
            /*PrintEditOperations(FirstWordLength, SecondWordLength);*/
        }

        private static double ReplaceOrMatch(char c1, char c2)
        {
            return (c1 == c2) ? 0 : 1.0;
        }

        private static double EditDistance()
        {
            for (var i = 0; i <= FirstWordLength; i++)
            {
                F[i, 0] = i * CostDelete;
            }

            for (var j = 0; j <= SecondWordLength; j++)
            {
                F[0, j] = j * CostInsert;
            }

            for (var i = 1; i <= FirstWordLength; i++)
            {
                for (var j = 1; j <= SecondWordLength; j++)
                {
                    F[i, j] = Math.Min(
                        F[i - 1, j - 1] + ReplaceOrMatch(FirstWord[i], SecondWord[j]),
                        Math.Min(F[i, j - 1] + CostInsert, F[i - 1, j] + CostDelete));
                }
            }

            return F[FirstWordLength, SecondWordLength];
        }

        private static void PrintEditOperations(int i, int j)
        {
            if (j == 0)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.WriteLine("delete '{0}'", FirstWord[i]);
                }
            }
            else if (i == 0)
            {
                for (i = 1; i <= j; i++)
                {
                    Console.WriteLine("insert '{0}'", SecondWord[i]);
                }
            }
            else if (i > 0 && j > 0)
            {
                if (Math.Abs(F[i, j] - (F[i - 1, j - 1] + ReplaceOrMatch(FirstWord[i], SecondWord[j]))) < Tolerance)
                {
                    PrintEditOperations(i - 1, j - 1);
                    if (ReplaceOrMatch(FirstWord[i], SecondWord[j]) > 0)
                    {
                        Console.WriteLine("replace '{0}'/'{1}'", SecondWord[j], FirstWord[i]);
                    }
                }
                else if (Math.Abs(F[i, j] - (F[i, j - 1] + CostInsert)) < Tolerance)
                {
                    PrintEditOperations(i, j - 1);
                    Console.WriteLine("insert '{0}'", SecondWord[j]);
                }
                else if (Math.Abs(F[i, j] - (F[i - 1, j] + CostDelete)) < Tolerance)
                {
                    PrintEditOperations(i - 1, j);
                    Console.WriteLine("delete {0}", i);
                }
            }
        }
    }
}
