
namespace IsoscelesTriangle
{
    using System;
    class IsoscelesTriangle
    {
        const int WIDTH = 9;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(@"
   ©

  © ©

 ©   ©

© © © ©
");
            //WithLoops();
        }

        private static void WithLoops()
        {
            Console.Clear();
            char copy = '\u00a9';

            string outerSpace = new String(' ', (WIDTH - 1) / 2);
            Console.WriteLine(outerSpace + copy + outerSpace);

            string innerSpace;
            for (int i = 0, j = 3; j > 0; i++, j--)
            {
                outerSpace = new String(' ', j);
                innerSpace = new String(' ', i * 2 + 1);

                Console.WriteLine(outerSpace + copy + innerSpace + copy);
            }

            for (int i = 0; i < WIDTH; i++)
            {
                if (i % 2 == 1) Console.Write(' ');
                else Console.Write(copy);
            }

            Console.WriteLine();
        }
    }
}
