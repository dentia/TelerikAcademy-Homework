using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingRocks
{
    public interface IPrintable
    {
        int X { get; set; }
        int Y { get; set; }
        ConsoleColor Color { get; set; }


        void Print();
    }
}
