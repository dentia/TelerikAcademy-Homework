namespace VariablePrinter
{
    public class PrintVariable
    {
        public static void Main()
        {
            var printer = new Printer.BooleanPrinter();
            printer.Print(true);
            printer.Print(false);
        }
    }
}
