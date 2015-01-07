using System;

namespace FallingRocks
{
    class GameInfo : IPrintable
    {
        private int x;
        private int y;
        private string message;
        private int amount;
        private ConsoleColor color;

        public GameInfo(int x, int y, string message, int amount, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            this.Message = message;
            this.Amount = amount;
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

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
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

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Message,
                (this.Amount > 0) ? this.Amount.ToString() : String.Empty);
        }

        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(this);
        }
    }
}
