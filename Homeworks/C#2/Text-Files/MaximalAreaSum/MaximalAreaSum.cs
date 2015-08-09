//Write a program that reads a text file containing a square matrix of numbers.
//Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.

namespace MaximalAreaSum
{
    using System;
    using System.IO;
    using System.Linq;
    class MaximalAreaSum
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\txt\05.matrix.txt";
            string outputPath = @"..\..\..\txt\05.matrixMaxAreaResult.txt";

            try
            {
                using (StreamReader stream = new StreamReader(inputPath))
                {
                    int size = int.Parse(stream.ReadLine());
                    int[,] matrix = new int[size, size];

                    GetMatrixNumbers(stream, matrix);
                    File.WriteAllText(outputPath, GetMaxArea(matrix).ToString());

                    Console.WriteLine("DIRECTORY: " +
                        Path.GetFullPath(outputPath).Replace(Path.GetFileName(outputPath), String.Empty));

                    Console.WriteLine("A file {0} has been created with the max area result.", 
                        Path.GetFileName(outputPath));
                }
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (FileLoadException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (EndOfStreamException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static int GetMaxArea(int[,] matrix)
        {
            int maxValue = 0;
            int tempValue;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    tempValue = 0;

                    for (int checkRow = 0; checkRow < 2; checkRow++)
                    {
                        for (int checkCol = 0; checkCol < 2; checkCol++)
                        {
                            tempValue += matrix[row + checkRow, col + checkCol];
                        }
                    }

                    maxValue = Math.Max(maxValue, tempValue);
                }
            }
            return maxValue;
        }

        private static void GetMatrixNumbers(StreamReader stream, int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentLineNumbers = stream.ReadLine()
                    .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentLineNumbers[col];
                }
            }
        }
    }
}
