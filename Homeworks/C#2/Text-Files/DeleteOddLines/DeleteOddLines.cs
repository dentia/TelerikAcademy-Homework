//Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

namespace DeleteOddLines
{
    using System;
    using System.IO;
    using System.Text;
    class DeleteOddLines
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\txt\09.deleteOddLines.txt";

            try
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine(@"

RESULT");
                using (StreamReader reader = File.OpenText(path))
                {
                    string currentLine;
                    int line = 0;

                    while (!reader.EndOfStream)
                    {
                        currentLine = reader.ReadLine();
                        ++line;
                        if (line % 2 == 0)
                        {
                            result.AppendLine(currentLine);
                        }
                    }

                }

                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(result);
                }

                Console.WriteLine("DIRECTORY: " +
                    Path.GetFullPath(path).Replace(Path.GetFileName(path), String.Empty));

                Console.WriteLine("The file {0} has been modified.",
                    Path.GetFileName(path));
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
    }
}
