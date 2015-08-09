namespace Abstraction
{
    using System;
    using System.Text;

    public class Rectangle : Figure, IFigure
    {
        private static const string InvalidWidthExceptionMessage = "Width cannot be less than or equal to 0.";
        private static const string InvalidHeightExceptionMessage = "Height cannot be less than or equal to 0.";
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException(Rectangle.InvalidWidthExceptionMessage);
                }

                this.width = value;
            }
        }

        public double Height 
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException(Rectangle.InvalidHeightExceptionMessage);
                }

                this.height = value;
            }
        }

        public override double GetPerimeter()
        {
            double perimeter = (2 * this.Width) + (2 * this.Height);
            return perimeter;
        }

        public override double GetSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine()
                .AppendFormat("Width: {0}; Height: {1}", this.Width, this.Height);

            return result.ToString();
        }
    }
}
