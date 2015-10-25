namespace Majorant
{
    using System;

    using Utils;
    using Utils.Predicates;
    using Utils.TextReader;

    public class StartUp
    {
        [STAThread]
        public static void Main()
        {
            new[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();
            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidInteger);

            var majorant = inputNumbers.GetMajorant();

            Console.WriteLine("Majorant: " + majorant);
        }
    }
}
