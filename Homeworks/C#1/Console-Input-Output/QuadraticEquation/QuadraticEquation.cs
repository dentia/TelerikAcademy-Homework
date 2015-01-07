using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            //D = b2 – 4ac
            Console.Write("Enter A:");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter B:");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter C:");
            double c = double.Parse(Console.ReadLine());

            double D = Math.Pow(b, 2) - 4 * a * c;
            if (D < 0)
            {
                Console.WriteLine("No real roots.");
            }
            else if (D == 0)
            {
                double x = -b/(2*a);
                Console.WriteLine("x1 = x2 = {0}", x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);

                Console.WriteLine("x1 = {0}\nx2 = {1}", x1, x2);
            }

            //while (true)
            //{
            //    Main(new string[] { });
            //}
        }
    }
}
