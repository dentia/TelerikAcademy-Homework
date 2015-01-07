using System;

namespace FallingRocks
{
    class Rock : IPrintable
    {
        private int x;
        private int y;
        private char symbol;
        private ConsoleColor color;
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

        public void SetRandom(int width)
        {
            Random generator = new Random();
            char[] symbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', ';' };
            ConsoleColor[] colors = {ConsoleColor.Red, ConsoleColor.DarkCyan,
                                    ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Magenta,
                                    ConsoleColor.DarkYellow, ConsoleColor.DarkRed, ConsoleColor.DarkGray,
                                    ConsoleColor.DarkGreen, ConsoleColor.DarkBlue};

            this.Y = 0;
            this.X = generator.Next(0, width);
            this.Color = colors[generator.Next(0, colors.Length)];
            this.Symbol = symbols[generator.Next(0, symbols.Length)];
        }
    }
}
