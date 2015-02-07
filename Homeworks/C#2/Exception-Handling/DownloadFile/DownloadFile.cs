//Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

namespace DownloadFile
{
    using System;
    using System.Net;
    using System.IO;
    class DownloadFile
    {
        const string URL = "http://telerikacademy.com/Content/Images/news-img01.png";
        const string FILE_NAME = "TelerikNinja.png";
        static void Main(string[] args)
        {
            try
            {
                WebClient webCilend = new WebClient();
                webCilend.DownloadFile(URL, FILE_NAME);
                Console.WriteLine("The picture is saved at {0}.", Directory.GetCurrentDirectory());
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (NotSupportedException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (WebException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
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
