namespace Abstraction
{
    using System.Text;

    public abstract class Figure : IFigure
    {
        protected Figure()
        {
        }

        public abstract double GetPerimeter();

        public abstract double GetSurface();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}", this.GetType().Name).AppendLine();
            result.AppendFormat("Area: {0:F4}; Perimeter: {1:F4}", this.GetSurface(), this.GetPerimeter());

            return result.ToString();
        }
    }
}
