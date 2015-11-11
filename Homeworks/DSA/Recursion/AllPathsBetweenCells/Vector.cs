namespace AllPathsBetweenCells
{
    using System;

    public class Vector : ICloneable, IComparable<Vector>
    {
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
        
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.X * 397) ^ this.Y;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("({0} {1})", this.Y, this.X);
        }

        public int CompareTo(Vector other)
        {
            var result = this.Y.CompareTo(other.Y);
            if (result != 0)
            {
                return result;
            }

            return this.X.CompareTo(other.X);
        }

        protected bool Equals(Vector other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.X == other.X && this.Y == other.Y;
        }
    }
}
