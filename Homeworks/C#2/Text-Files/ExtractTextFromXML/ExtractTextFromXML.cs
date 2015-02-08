//Write a program that extracts from given XML file all the text without the tags.

namespace ExtractTextFromXML
{
    using System;
    using System.IO;
    using System.Text;
    class ExtractTextFromXML
    {
        const char SPACE = ' ';
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\txt\10.pesho.xml";
            string outputPath = @"..\..\..\txt\10.peshoOutput.txt";

            try
            {
                using (StreamReader reader = new StreamReader(inputPath))
                {
                    string xml = reader.ReadToEnd();

                    using (StreamWriter writer = new StreamWriter(outputPath))
                    {
                        writer.Write(GetResult(xml));

                        Console.WriteLine("DIRECTORY: " +
                            Path.GetFullPath(outputPath).Replace(Path.GetFileName(outputPath), String.Empty));

                        Console.WriteLine("A file {0} with {1} text content has been created.",
                            Path.GetFileName(outputPath), Path.GetFileName(inputPath));
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

        private static string GetResult(string xml)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder current = new StringBuilder();
            bool insideTag = false;

            foreach (var letter in xml)
            {
                if (insideTag)
                {
                    if (letter == '>')
                    {
                        insideTag = false;
                    }
                    continue;
                }
                else
                {
                    if (letter == '<')
                    {
                        if (current.Length > 0)
                        {
                            result.AppendLine(current.ToString());
                            current.Clear();
                        }
                        insideTag = true;
                    }
                    else
                    {
                        current.Append(letter);
                    }
                    continue;
                }
            }
            return result.ToString();
        }
    }
}
