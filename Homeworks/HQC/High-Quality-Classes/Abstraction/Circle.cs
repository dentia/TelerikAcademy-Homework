namespace Abstraction
{
    using System;
    using System.Text;

    public class Circle : Figure, IFigure
    {
        private static const string InvalidRadiusExceptionMessage = "Radius cannot be less than or equal to 0.";
        private double radius;

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set 
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException(Circle.InvalidRadiusExceptionMessage);
                }

                this.radius = value;
            }
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double GetSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine()
                .AppendFormat("Radius: {0}", this.Radius);

            return result.ToString();
        }
    }
}
