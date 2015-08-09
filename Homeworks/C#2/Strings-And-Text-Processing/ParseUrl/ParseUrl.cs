//Write a program that parses an URL address given in the format: 
//[protocol]://[server]/[resource] and extracts from it the 
//[protocol], [server] and [resource] elements.

namespace ParseUrl
{
    using System;
    using System.Text.RegularExpressions;
    class ParseUrl
    {
        static void Main(string[] args)
        {
            Console.Write("Enter URL: ");
            string url = Console.ReadLine();
//http://telerikacademy.com/Courses/Courses/Details/212

            Uri uri = new Uri(url);
            string protocol = uri.Scheme;
            string server = uri.Host;
            string resource = uri.AbsolutePath;

            Console.WriteLine(@"
[protocol]  {0}
[server]    {1}
[resource]  {2}
", protocol, server, resource);
        }
    }
}
