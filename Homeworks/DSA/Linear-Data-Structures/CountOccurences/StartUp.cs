namespace CountOccurences
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
            new[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();
            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidIntegerTo1000);

            var numbersCount = inputNumbers.GetOccurenceCount();
            numbersCount.ForEach(x => Console.WriteLine("{0} -> {1} times", x.Key, x.Value));
        }
    }
}
