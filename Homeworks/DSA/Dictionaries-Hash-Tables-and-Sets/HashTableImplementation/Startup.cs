namespace HashTableImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var table = new CustomHashTable<int, string>();
            
            for (int i = 0; i < 50; i++)
            {
                table.Add(i, i.ToString());
            }

            System.Console.WriteLine(table);
            System.Console.WriteLine(table.Count);
        }
    }
}
