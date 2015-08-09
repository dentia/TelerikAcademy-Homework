
namespace Space3D
{
    using System;
    using IO = System.IO;
    using System.Linq;
    public static class PathStorage
    {
        public static void Save(Path path, string pathName)
        {
            string fullPath = IO.Path.Combine(@"..\..\Paths", String.Format("{0}.txt", pathName.Trim()));
            using (IO.StreamWriter writer = IO.File.CreateText(fullPath))
            {
                writer.Write(path);
            }
        }

        public static Path Load(string pathName)
        {
            Path path = new Path();
            string fullPath = IO.Path.Combine(@"..\..\Paths", String.Format("{0}.txt", pathName.Trim()));

            try
            {
                using (IO.StreamReader reader = new IO.StreamReader(fullPath))
                {
                    string[] allPoints = reader.ReadToEnd()
                        .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var point in allPoints)
                    {
                        double[] coordinates = point.Trim('{').Trim('}')
                            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => double.Parse(x))
                            .ToArray();

                        path.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
                    }
                }
            }
            catch (IO.FileNotFoundException)
            {
                Console.Write("The path \"{0}\" cannot be found.", pathName);
                return null;
            }

            return path;
        }
    }
}
