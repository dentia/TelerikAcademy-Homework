namespace QueueSequence
{
    using System;

    using Utils;
    using Utils.TextReader;

    public class StartUp
    {
        public static void Main()
        {
            var reader = new Reader();
            var inputNumber = reader.ReadOne();

            var sequence = inputNumber.GetSpecialSequence(50);
            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
