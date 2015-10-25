namespace SumAndAverageSequence
{
    using System;
    using System.Linq;

    using Utils;
    using Utils.Predicates;
    using Utils.TextReader;

    public class StartUp
    {
        [STAThread]
        public static void Main()
        {
            new[] { 1, 2, 3, 4, 5 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();

            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidPositiveInteger);
            Console.WriteLine(inputNumbers.Sum());
            Console.WriteLine(inputNumbers.Average());
        }
    }
}
