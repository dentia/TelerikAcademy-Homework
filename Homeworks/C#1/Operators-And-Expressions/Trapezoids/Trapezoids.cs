//Write an expression that calculates trapezoid's area by given sides a and b and height h.
namespace Trapezoids
{
    using System;
    class Trapezoids
    {
        static void Main(string[] args)
        {
            Console.Write("Enter side A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter side B: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            double height = double.Parse(Console.ReadLine());

            double area = ((sideA + sideB) / 2) * height;

            Console.WriteLine("Area:\t{0:F2}", area);
        }
    }
}
