namespace Exam_Cube3D
{
    using System;
    using System.Text;

    public class Cube3D
    {
        private const char Collon = ':';
        private const char Space = ' ';
        private const char Dash = '-';
        private const char Line = '|';

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int width = GetCubeSide(size);
            int heght = GetCubeSide(size);

            Console.WriteLine(GetCube3D(size, width, heght));
        }

        public static string GetCube3D(int size, int width, int height)
        {
            string borderSide = new string(Collon, size);
            string borderSpace = new string(Space, size - 1);
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{0}{1}", borderSide, borderSpace)
                .AppendLine();

            string space;
            string lines;
            string endSpace;
            for (int row = 0; row < size - 2; row++)
            {
                space = new string(Space, size - 2);
                lines = new string(Line, row);
                endSpace = new string(Space, width - (size + row + 1));

                output.AppendFormat("{0}{1}{0}{2}{0}{3}", Collon, space, lines, endSpace)
                    .AppendLine();
            }

            output.AppendFormat("{0}{1}{2}", borderSide, new string(Line, size - 2), Collon)
                .AppendLine();

            string bottomSide = string.Format("{0}{1}{0}", Collon, new string(Dash, size - 2));
            for (int row = size - 3; row >= 0; row--)
            {
                space = new string(Space, width - (size + row + 1));
                lines = new string(Line, row);
                output.AppendFormat("{0}{1}{2}{3}", space, bottomSide, lines, Collon)
                    .AppendLine();
            }

            output.AppendFormat("{0}{1}", borderSpace, borderSide);

            return output.ToString();
        }

        private static int GetCubeSide(int size)
        {
            return (size * 2) - 1;
        }
    }
}
