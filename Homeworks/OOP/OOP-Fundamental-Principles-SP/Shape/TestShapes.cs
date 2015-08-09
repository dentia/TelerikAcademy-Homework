
namespace Shape
{
    using System;
    class TestShapes
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]{
                new Circle(10),
                new Triangle(5,10),
                new Rectangle(5,10)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
