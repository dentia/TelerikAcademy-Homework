
namespace Shape
{
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Shape(double parameter)
        {
            this.Width = parameter;
            this.Height = parameter;
        }
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double CalculateSurface()
        {
            return 0.0;
        }
    }
}
