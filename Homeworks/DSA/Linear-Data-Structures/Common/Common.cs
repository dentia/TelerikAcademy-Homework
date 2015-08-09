namespace Common
{
    using System;
    using System.Collections.Generic;

    public static class Common
    {
        public static List<int> ReadInput()
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) break;
                numbers.Add(int.Parse(line));
            }

            return numbers;
        }
    }
}