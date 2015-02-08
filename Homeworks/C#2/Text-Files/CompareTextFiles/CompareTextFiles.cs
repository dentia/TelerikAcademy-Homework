//Write a program that compares two text files 
//line by line and prints the number of lines 
//that are the same and the number of lines that are different.
//Assume the files have equal number of lines.

namespace CompareTextFiles
{
    using System;
    using System.IO;
    class CompareTextFiles
    {
        static void Main(string[] args)
        {
            string firstFile = @"..\..\..\txt\04.first.txt";
            string secondFile = @"..\..\..\txt\04.second.txt";

            int sameCount = 0;
            int differentCount = 0;
            try
            {
                StreamReader firstStream = new StreamReader(firstFile);
                StreamReader secondStream = new StreamReader(secondFile);
                using (firstStream)
                {
                    using (secondStream)
                    {
                        string firstLine;
                        string secondLine;

                        firstLine = firstStream.ReadLine();
                        secondLine = secondStream.ReadLine();
                        while (firstLine != null && secondLine != null)
                        {
                            if (firstLine == secondLine)
                            {
                                ++sameCount;
                            }
                            else
                            {
                                ++differentCount;
                            }
                            firstLine = firstStream.ReadLine();
                            secondLine = secondStream.ReadLine();
                        }

                        Console.WriteLine(@"
SAME LINES COUNT:       {0}
DIFFERENT LINES COUNT:  {1}
", sameCount, differentCount);
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
        }
    }
}
