//Write a program that removes from a text file all words listed in given another text file.
//Handle all possible exceptions in your methods.

namespace RemoveWords
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    class RemoveWords
    {
        static void Main(string[] args)
        {
            string forbiddenWords = @"..\..\..\txt\12.forbiddenWords.txt";
            string inputPath = @"..\..\..\txt\12.textToCensore.txt";
            List<string> result = new List<string>();
            List<string> forbidden = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(forbiddenWords))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] words = reader.ReadLine()
                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                        forbidden.AddRange(words);
                    }
                }
                using (StreamReader reader = new StreamReader(inputPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] words = reader.ReadLine()
                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(x => !forbidden.Contains(x))
                            .ToArray();

                        result.AddRange(words);
                    }
                }

                using (StreamWriter writer = new StreamWriter(inputPath))
                {
                    writer.Write(String.Join(Environment.NewLine, result));

                    Console.WriteLine("DIRECTORY: " +
                       Path.GetFullPath(inputPath).Replace(Path.GetFileName(inputPath), String.Empty));

                    Console.WriteLine("The file {0} has been ccensored.",
                        Path.GetFileName(inputPath));
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
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
