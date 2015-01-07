
namespace SpiralMatrix
{
    public class Pair<T1, T2>
    {
        public Pair(T1 vert, T2 hor)
        {
            this.Height = vert;
            this.Width = hor;
        }
        public T1 Height { get; set; }
        public T2 Width { get; set; }
    }
}
