//Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).

namespace PointInCircle
{
    using System;
    using System.Linq;
    class PointInCircle
    {
        const double radius = 2;
        const double xY = 0;
        static void Main(string[] args)
        {
            Console.Write("Enter the coordinates X and Y separated by a space. ");
            double[] coords = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(h => Double.Parse(h))
                .ToArray();

            Console.WriteLine("The point is {0} the circle.",
                IsInside(coords[0], coords[1]) ? "INSIDE" : "OUTSIDE");
        }

        static bool IsInside(double x, double y)
        {
            return (Math.Pow((xY - x), 2) + Math.Pow((xY - y), 2) <= radius * radius);
        }
    }
}
