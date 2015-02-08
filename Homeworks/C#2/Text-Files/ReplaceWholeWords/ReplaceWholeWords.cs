//Modify the solution of the previous problem to replace only whole words (not strings).

namespace ReplaceWholeWords
{
    using System;
    using System.IO;
    using System.Text;
    class ReplaceWholeWords
    {
        const string FROM = "start";
        const string TO = "finish";
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\txt\08.input.txt";
            string outputPath = @"..\..\..\txt\08.output.txt";

            try
            {
                using (StreamReader reader = new StreamReader(inputPath))
                {
                    StringBuilder currentLine;
                    using (StreamWriter writer = new StreamWriter(outputPath))
                    {
                        while (!reader.EndOfStream)
                        {
                            currentLine = new StringBuilder(reader.ReadLine());
                            writer.WriteLine(Replace(currentLine));
                        }

                        Console.WriteLine("DIRECTORY: " +
                        Path.GetFullPath(outputPath).Replace(Path.GetFileName(outputPath), String.Empty));

                        Console.WriteLine("A file {0} has been created with the replaced text.",
                            Path.GetFileName(outputPath));
                    }
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
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static string Replace(StringBuilder currentLine)
        {
            int startIndex = 0;
            string checkLine = currentLine.ToString();
            while (startIndex < currentLine.Length && 
                checkLine.IndexOf(FROM, StringComparison.OrdinalIgnoreCase) != -1)
            {
                startIndex = checkLine.IndexOf(FROM, StringComparison.OrdinalIgnoreCase);
                bool startOfWord = (startIndex == 0 ||
                    !Char.IsLetterOrDigit(currentLine[startIndex - 1]));

                bool endOfWord = ((startIndex + FROM.Length) == currentLine.Length ||
                    !Char.IsLetterOrDigit(currentLine[startIndex + FROM.Length]));

                if (startOfWord && endOfWord)
                {
                    currentLine = currentLine
                        .Replace(currentLine.ToString()
                        .Substring(startIndex, FROM.Length),
                        TO, startIndex, FROM.Length);
                }

                startIndex += TO.Length;
                checkLine = currentLine.ToString().Substring(startIndex);
                checkLine = checkLine.PadLeft(currentLine.Length, '*');
            }

            return currentLine.ToString();
        }
    }
}
