//Find online more information about ASCII (American Standard Code for Information Interchange)
//and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
//Note: Some characters have a special purpose and will not be displayed as expected. 
//You may skip them or display them differently.

namespace PrintASCIITable
{
    using System;
    class PrintASCIITable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All printable characters: ");
            for (int i = 0; i < 256; i++)
            {
                  char c = Convert.ToChar(i);
                  if (!char.IsControl(c)) Console.WriteLine(i + "\t" + c);
            }
            Console.WriteLine((char)7);//bell
        }
    }
}
