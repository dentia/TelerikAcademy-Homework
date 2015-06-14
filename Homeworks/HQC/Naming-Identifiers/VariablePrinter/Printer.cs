namespace VariablePrinter
{
    using System;

    public class Printer
    {
        private const int MaxCount = 6;

        public class BooleanPrinter
        {
            public BooleanPrinter()
            {
            }

            public void Print(bool value)
            {
                Console.WriteLine(value);
            }
        }
    }
}