namespace RotatingWalkInMatrix
{
    internal class RotatingWalkInMatrix
    {
        internal static void Main()
        {
            SquareMatrix matrix = new SquareMatrix(7);
            matrix.RotatingWalkFill();
            System.Console.WriteLine(matrix);
        }
    }
}
