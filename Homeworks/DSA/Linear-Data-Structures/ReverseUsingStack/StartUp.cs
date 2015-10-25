namespace ReverseUsingStack
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
            new[] { -2, -2, 0, 3, 4, 5, 6, 7, 8, 12 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();

            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidInteger);
            var reversedNumbers = inputNumbers.StackReverse();
            reversedNumbers.ForEach(x => Console.Write("{0}  ", x));
        }
    }
}
