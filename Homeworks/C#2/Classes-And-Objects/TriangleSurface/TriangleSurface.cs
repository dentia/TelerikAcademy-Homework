//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it;
//Three sides;
//Two sides and an angle between them;
//Use System.Math.

namespace TriangleSurface
{
    using System;
    class TriangleSurface
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            decimal sideA = 5.0m;
            decimal sideB = 6.0m;
            decimal sideC = 3.0m;

            decimal heightToA = 3.0m;
            decimal angleAB = 30.0m;

            decimal area;
            area = GivenSides(sideA, sideB, sideC);
            Console.WriteLine("Three sides:         ≈{0:F1}", area);

            area = HeightAndSide(sideA, heightToA);
            Console.WriteLine("Height and side:     ≈{0:F1}", area);

            area = SidesAndAngle(sideA, sideB, angleAB);
            Console.WriteLine("Two sides and angle: ≈{0:F1}", area);

        }

        private static decimal SidesAndAngle(decimal sideA, decimal sideB, decimal angleAB)
        {
            angleAB = angleAB * (decimal)Math.PI / 180.0m;
            return ((decimal)Math.Sin((double)angleAB) * sideA * sideB) / 2.0m;
        }

        private static decimal HeightAndSide(decimal sideA, decimal heightToA)
        {
            return (sideA * heightToA) / 2.0m;
        }

        private static decimal GivenSides(decimal sideA, decimal sideB, decimal sideC)
        {
            decimal p = (sideA + sideB + sideC) / 2;
            return (decimal)Math.Sqrt((double)(p * (p - sideA) * (p - sideB) * (p - sideC)));
        }
    }
}
