namespace Phones
{
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var phoneBook = new Phonebook();
            phoneBook.Add(new Entry("Mimi Ivanova Shmatkata", "Plovdiv", "0888 12 34 56"));
            phoneBook.Add(new Entry("Kireto", "Varna", "052 23 45 67"));
            phoneBook.Add(new Entry("Daniela Ivanova Petrova", "Karnobat", "0899 999 888"));
            phoneBook.Add(new Entry("Bat Gancho", "Sofia", "02 946 946 946"));

            var resultByName = phoneBook.Find("Ivanova");
            var resultByNameAndTown = phoneBook.Find("Bat", "Sofia");
            var emptySearch = phoneBook.Find("NoSuchEntry");

            PrintResults(resultByName);
            PrintResults(resultByNameAndTown);
            PrintResults(emptySearch);
        }

        private static void PrintResults(ICollection<Entry> entries)
        {
            System.Console.WriteLine(string.Join("|||", entries));
            System.Console.WriteLine();
        }
    }
}
