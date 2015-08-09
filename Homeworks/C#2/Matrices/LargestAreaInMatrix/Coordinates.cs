using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInMatrix
{
    class Coordinates
    {
        private int x;
        private int y;

        public int X { get { return this.x; } private set { this.x = value; } }
        public int Y { get { return this.y; } private set { this.y = value; } }

        public Coordinates(int firstDimension, int secondDimension)
        {
            this.X = firstDimension;
            this.Y = secondDimension;
        }
    }
}
