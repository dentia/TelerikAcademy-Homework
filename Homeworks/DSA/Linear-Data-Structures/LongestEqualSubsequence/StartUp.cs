namespace LongestEqualSubsequence
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
            new[] { 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();
            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidInteger);

            var longestSubsequence = inputNumbers.GetLongestEqualSubsequence();
            Console.WriteLine(string.Join(" ", longestSubsequence));
        }
    }
}
