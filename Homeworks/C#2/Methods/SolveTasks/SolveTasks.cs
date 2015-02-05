//Write a program that can solve these tasks:
        //Reverses the digits of a number
        //Calculates the average of a sequence of integers
        //Solves a linear equation a * x + b = 0
//Create appropriate methods.
//Provide a simple text-based menu for the user to choose which task to solve.
//Validate the input data:
        //The decimal number should be non-negative
        //The sequence should not be empty
        //a should not be equal to 0
namespace SolveTasks
{
    using System;
    using System.Linq;
    using System.Threading;
    class SolveTasks
    {
        static void Main(string[] args)
        {
            switch (GetChoise())
            {
                case Task.Reverse:
                    ReverseNumber();
                    break;
                case Task.Average:
                    GetAverage();
                    break;
                case Task.Equation:
                    SolveEquation();
                    break;
            }
        }

        private static Task GetChoise()
        {
            ConsoleColor defaultBackground = ConsoleColor.White;
            ConsoleColor choiseBackground = ConsoleColor.Black;
            ConsoleColor defaultForeGround = ConsoleColor.Black;
            ConsoleColor choiseForeGround = ConsoleColor.White;
            int choise = 0;
            string[] choises = new string[] 
            { "REVERSE THE DIGITS OF A NUMBER", "GET THE AVERAGE OF NUMBER SEQUENCE", "SOLVE LINEAR EQUATION" };

            while (true)
            {
                Console.Clear();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressed = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);

                    if (pressed.Key == ConsoleKey.UpArrow)
                    {
                        --choise;
                        if (choise == -1)
                            choise = 2;
                    }
                    else if (pressed.Key == ConsoleKey.DownArrow)
                    {
                        ++choise;
                        choise %= 3;
                    }
                    else if (pressed.Key == ConsoleKey.Enter)
                    {
                        Console.ForegroundColor = defaultForeGround;
                        Console.BackgroundColor = defaultBackground;
                        return (Task)choise;
                    }
                }
                for (int currentChoise = 0; currentChoise < choises.Length; currentChoise++)
                {
                    if (currentChoise == choise)
                    {
                        Console.ForegroundColor = choiseForeGround;
                        Console.BackgroundColor = choiseBackground;
                    }
                        
                    Console.WriteLine(choises[currentChoise]);
                    Console.ForegroundColor = defaultForeGround;
                    Console.BackgroundColor = defaultBackground;
                }
                Thread.Sleep(100);
            }
        }

        private static void SolveEquation()
        {
            Console.WriteLine("a * x + b = 0\n".ToUpper());
            double a;
            bool aIsNotZero = true;

            do
            {
                if(!aIsNotZero)
                    Console.WriteLine("A must be different than 0.");

                Console.Write("Enter A: ");
                a = double.Parse(Console.ReadLine());

                aIsNotZero = a != 0;
            } while (!aIsNotZero);
            
            Console.Write("Enter B: ");
            double b = double.Parse(Console.ReadLine());

            double result = -b / a;
            Console.WriteLine("X = {0:F3}", result);
        }

        private static void GetAverage()
        {
            Console.WriteLine("Get average\n".ToUpper());
            bool notEmpty = true;
            double[] numbers;
            do
            {
                if(!notEmpty)
                    Console.WriteLine("There sequence cannot be empty!");

                Console.WriteLine("Enter numbers, separated by a comma: ");
                numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();

                notEmpty = numbers.Length > 0;
            } while (!notEmpty);
            

            double result = numbers.Sum() / numbers.Length;
            Console.WriteLine("Average: {0:F3}", result);
        }

        private static void ReverseNumber()
        {
            Console.WriteLine("Reverse digits\n".ToUpper());
            int number;
            bool numbersIsPossitive = true;
            do
            {
                if (!numbersIsPossitive)
                    Console.WriteLine("The number must be positive!");

                Console.WriteLine("Enter an intger: ");
                number = int.Parse(Console.ReadLine());

                numbersIsPossitive = number > 0;
            } while (!numbersIsPossitive);
            long result = 0;

            while (number > 0)
            {
                result *= 10;
                result += number % 10;
                number /= 10;
            }

            Console.WriteLine("Reversed: " + result);
        }
    }
}
