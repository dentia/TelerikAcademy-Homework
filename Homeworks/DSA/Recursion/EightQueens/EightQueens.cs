namespace EightQueens
{
    using System;

    public class EightQueens
    {
        public static void Main()
        {
            var queensSolver = new QueensSolver(8);
            queensSolver.FindAllSolutions();
            Console.WriteLine(queensSolver.SolutionsCount);
        }
    }
}
