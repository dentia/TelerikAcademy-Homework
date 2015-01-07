using System;

namespace FallingRocks
{
    class Player : IPrintable
    {
        private int x;
        private int y;
        private char symbol;
        private ConsoleColor color;

        public Player(int x, int y, char symbol, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
            this.Color = color;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public char Symbol 
        {
            get 
            {
                return this.symbol;
            }
            set 
            {
                this.symbol = value;
            } 
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Symbol);
        }
    }
}
