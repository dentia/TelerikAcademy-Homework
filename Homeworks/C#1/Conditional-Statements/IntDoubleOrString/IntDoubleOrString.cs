//Write a program that, depending on the user’s choice, inputs an int, double or string variable.
//If the variable is int or double, the program increases it by one.
//If the variable is a string, the program appends * at the end.
//Print the result at the console. Use switch statement.

namespace IntDoubleOrString
{
    using System;
    class IntDoubleOrString
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
Plese choose:
I -> integer
D -> double
S -> string");
            
            char choise = Console.ReadLine().Trim().ToUpper()[0];
            Console.Clear();
            Console.WriteLine(GetResult(choise));
        }

        private static string GetResult(char choise)
        {
            switch (choise)
            {
                case 'I':
                    Console.Write("Enter a number: ");
                    int inputInt = int.Parse(Console.ReadLine());
                    return (inputInt + 1).ToString();
                case 'D':
                    Console.Write("Enter a number: ");
                    double inputDouble = double.Parse(Console.ReadLine());
                    return (inputDouble + 1).ToString();
                case 'S':
                    Console.Write("Enter a string: ");
                    string inputString = Console.ReadLine();
                    return ("*" + inputString);
                default:
                    return "Invalid command!";
            }
        }
    }
}
