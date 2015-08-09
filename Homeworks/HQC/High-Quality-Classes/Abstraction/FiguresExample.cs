namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            IFigure circle = new Circle(5.0);
            Console.WriteLine(circle + Environment.NewLine);

            IFigure rectangle = new Rectangle(10.2, 5.2);
            Console.WriteLine(rectangle);
        }
    }
}
