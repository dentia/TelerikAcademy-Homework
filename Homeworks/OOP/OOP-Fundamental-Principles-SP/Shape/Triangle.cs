
namespace Shape
{
    public class Triangle : Shape
    {
        public Triangle(double _base, double height)
            : base(_base, height)
        {

        }

        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2.0;
        }
    }
}
