//Write a program that enters file name along with its full file path 
//(e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
//Find in MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions and print user-friendly error messages.

namespace ReadFileContents
{
    using System;
    using System.IO;
    class ReadFileContents
    {
        static void Main(string[] args)
        {
//C:\WINDOWS\win.ini
            Console.Write("Enter full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    Console.WriteLine(stream.ReadToEnd());
                }
            }
            catch (FileLoadException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (EndOfStreamException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DriveNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (PathTooLongException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}
