namespace BinaryPasswords
{
    using System;
    using System.Linq;

    public class BinaryPasswords
    {
        public static void Main()
        {
            Console.WriteLine(1L << Console.ReadLine().Count(x => x == '*'));
        }
    }
}
