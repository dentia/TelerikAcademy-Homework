//Write an expression that calculates rectangle’s perimeter and area by given width and height.
namespace Rectangles
{
    using System;
    class Rectangles
    {
        static void Main(string[] args)
        {
            Console.Write("Enter width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine(CalculatePerimeterAndArea(width, height));
        }

        private static string CalculatePerimeterAndArea(double width, double height)
        {
            double perimeter = 2 * width + 2 * height;
            double area = width * height;

            return string.Format("Perimeter: {0:F2}\nArea: {1:F2}", perimeter, area);
        }
    }
}
