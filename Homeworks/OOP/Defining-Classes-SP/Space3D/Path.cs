
namespace Space3D
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }

        public int Count
        {
            get
            {
                return this.points.Count;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                return this.points[index];
            }
            set
            {
                this.points[index] = value;
            }
        }

        public void AddPoint(Point3D p)
        {
            this.points.Add(p);
        }

        public void AddPoints(params Point3D[] p)
        {
            this.points.AddRange(p);
        }

        public void AddPoints(ICollection<Point3D> p)
        {
            this.points.AddRange(p);
        }

        public override string ToString()
        {
            return String.Join(" -> ", this.points);
        }
    }
}
