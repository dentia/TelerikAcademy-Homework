namespace RotatingWalkInMatrix.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProjectTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CoordinatesShouldThrowExceptionWhenNegativeValuesPassed()
        {
            Coordinates coords = new Coordinates(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixShouldThrowExceptionWhenNegativeSizePassed()
        {
            var matrix = new SquareMatrix(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixShouldThrowExceptionWhenSizeIsLessThanMinimum()
        {
            var matrix = new SquareMatrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixShouldThrowExceptionWhenSizeIsBiggerThanMaximum()
        {
            var matrix = new SquareMatrix(101);
        }

        [TestMethod]
        public void MatrixShouldReturnCorrectMatrixOfSize1()
        {
            var matrix = new SquareMatrix(1);
            matrix.RotatingWalkFill();
            var expected = new int[,] { { 1 } };

            Assert.IsTrue(this.MatricesAreEqual(expected, matrix.Matrix));
        }

        [TestMethod]
        public void MatrixShouldReturnCorrectMatrixOfSize3()
        {
            var matrix = new SquareMatrix(3);
            matrix.RotatingWalkFill();
            var expected = new int[,] 
            { 
                { 1, 7, 8 },
                { 6, 2, 9 },
                { 5, 4, 3 }
            };

            Assert.IsTrue(this.MatricesAreEqual(expected, matrix.Matrix));
        }

        [TestMethod]
        public void MatrixShouldReturnCorrectMatrixOfSize6()
        {
            var matrix = new SquareMatrix(6);
            matrix.RotatingWalkFill();
            var expected = new int[,] 
            { 
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 30, 3, 26, 30, 22 },
                { 13, 35, 31, 4, 25, 23 },
                { 12, 34, 33, 32, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            Assert.IsTrue(this.MatricesAreEqual(expected, matrix.Matrix));
        }

        private bool MatricesAreEqual(int[,] expected, int[,] actual)
        {
            if (expected.GetLength(0) != actual.GetLength(0) || expected.GetLength(1) != actual.GetLength(1))
            {
                return false;
            }

            for (int row = 0; row < expected.GetLength(0); row++)
            {
                for (int col = 0; col < expected.GetLength(1); col++)
                {
                    if (expected[row, col] != actual[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
