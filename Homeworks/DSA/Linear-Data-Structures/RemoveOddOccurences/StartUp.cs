namespace RemoveOddOccurences
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
            new[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();
            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidInteger);

            var onlyEvenOccurences = inputNumbers.RemoveOddOccurences();
            Console.WriteLine(string.Join(" ", onlyEvenOccurences));
        }
    }
}
