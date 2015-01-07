//Write a program that reads the radius r of a circle and prints its perimeter 
//and area formatted with 2 digits after the decimal point.

namespace CirclePerimeterAndArea
{
    using System;
    class CirclePerimeterAndArea
    {
        static void Main(string[] args)
        {
            Console.Write("Enter radius: ");
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * radius * radius;
            double perimeter = Math.PI * 2 * radius;

            Console.Clear();
            Console.WriteLine(@"
Area:       {0}
Perimeter:  {1}
".Trim(), Math.Round(area, 2), Math.Round(perimeter, 2));
        }
    }
}
