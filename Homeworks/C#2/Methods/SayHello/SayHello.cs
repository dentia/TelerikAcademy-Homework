//Write a method that asks the user for his name and prints “Hello, <name>”
//Write a program to test this method.

namespace SayHello
{
    using System;
    public class SayHello
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine(ReturnGreeting(name));
        }

        public static string ReturnGreeting(string name)
        {
            return String.Format("Hello, {0}!", name);
        }
    }
}
