namespace BiDictionary
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dictionary = new BiDictionary<int, string, string>(true);
            dictionary.Add(1, "1", "value 1");
            dictionary.Add(2, "2", "value 2");
            dictionary.Add(3, "3", "value 3");
            dictionary.Add(3, "3", "value 3.1");

            Console.WriteLine(string.Join(", ", dictionary.FindByFirstKey(1)));
            Console.WriteLine(string.Join(", ", dictionary.FindBySecondKey("2")));
            Console.WriteLine(string.Join(", ", dictionary.FindByBothKeys(3, "3")));
        }
    }
}
