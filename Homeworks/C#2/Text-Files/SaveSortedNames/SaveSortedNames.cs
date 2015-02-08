//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

namespace SaveSortedNames
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class SaveSortedNames
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\txt\06.names.txt";
            string outputPath = @"..\..\..\txt\06.sortedNames.txt";

            try
            {
                List<string> names = new List<string>();

                using (StreamReader stream = new StreamReader(inputPath))
                {
                    names = stream.ReadToEnd()
                        .Split('\n')
                        .Select(x => x.Trim())
                        .OrderBy(x => x)
                        .ToList();

                    File.WriteAllLines(outputPath, names);

                    Console.WriteLine("DIRECTORY: " +
                        Path.GetFullPath(outputPath).Replace(Path.GetFileName(outputPath), String.Empty));

                    Console.WriteLine("A file {0} has been created with the sorted names.",
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
        }
    }
}
