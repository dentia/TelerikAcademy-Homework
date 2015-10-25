namespace OrderByAscending
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
            new[] { 9, 5, 7, 3, 1, 0, 5, 2, 8, 6, -2, -10, 0, 0 }.CopyArrayToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var predicates = new PredicateProvider();
            var reader = new Reader();

            var inputNumbers = reader.ReadList(predicates.ShouldStopReading, predicates.IsValidInteger);
            inputNumbers.OrderBy(x => x)
                .ForEach(x => Console.Write("{0}  ", x));
        }
    }
}
