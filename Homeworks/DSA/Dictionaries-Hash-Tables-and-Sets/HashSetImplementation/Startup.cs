namespace HashSetImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var set = new HashedSet<int>();

            for (int i = 1; i < 11; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    set.Add(i);
                }
            }

            System.Console.WriteLine(set);
            System.Console.WriteLine(set.Count);

            var otherSet = new HashedSet<int>();

            for (int i = 5; i < 16; i++)
            {
                otherSet.Add(i);
            }

            System.Console.WriteLine(otherSet);
            System.Console.WriteLine(otherSet.Count);
            System.Console.WriteLine(set.IntersectsWith(otherSet));
            System.Console.WriteLine(set.Union(otherSet));
        }
    }
}
