namespace RemoveNegativeNumbers
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
            new[] { 1, 0, -10, 4, -5, 3, 7, 6, 8, -8, -2, -4, 5 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();
            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidInteger);

            var onlyPositive = inputNumbers.GetOnlyPositiveNumbers();
            Console.WriteLine(string.Join(" ", onlyPositive));
        }
    }
}
