
namespace GenericList
{
    using System;
    using System.Text;
    class Test
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>(5);
            StringBuilder result = new StringBuilder();
            list.Add(3);
            list.InsertAt(0, 2);
            list.InsertAt(0, 1);
            result.AppendLine(list.ToString());
            result.AppendLine(String.Format("Count: {0}", list.Count));

            result.AppendLine("--REMOVE AT INDEX 1--");
            list.RemoveAt(1);
            result.AppendLine(list.ToString());
            result.AppendLine(String.Format("Count: {0}", list.Count));

            result.AppendLine("     MIN: " + list.Min());
            result.AppendLine("     MAX: " + list.Max());

            result.AppendLine("-----INDEX OF 3-----");
            result.AppendLine(list.IndexOf(3).ToString());
            result.AppendLine("-----INDEX OF 2-----");
            result.AppendLine(list.IndexOf(2).ToString());

            result.AppendLine("-----CLEAR LIST-----");
            list.Clear();
            result.AppendLine(list.ToString());
            result.AppendLine(String.Format("Count: {0}", list.Count));

            Console.WriteLine(result);
        }
    }
}
