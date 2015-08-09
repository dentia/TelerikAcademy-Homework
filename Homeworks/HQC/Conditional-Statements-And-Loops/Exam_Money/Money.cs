namespace Exam_Money
{
    using System;

    public class Money
    {
        private const decimal PapersPerRealm = 400.0m;

        public static void Main()
        {
            int numberOfSutdents = int.Parse(Console.ReadLine());
            int sheets = int.Parse(Console.ReadLine());
            decimal prisePerRealm = decimal.Parse(Console.ReadLine());

            // the explicit convertion to long will prevent int overflow
            decimal realms = ((long)numberOfSutdents * sheets) / PapersPerRealm;

            Console.WriteLine("{0:F3}", realms * prisePerRealm);
        }
    }
}
