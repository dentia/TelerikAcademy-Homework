
namespace Space3D
{
    class Test
    {
        static void Main()
        {
            Point3D p = Point3D.StartPoint;
            Point3D q = new Point3D(1, 2, 3);
            System.Console.WriteLine("Distance: {0:F4}", DistanceCalculator.Calculate(p, q));

            Path path = new Path();
            path.AddPoints(p, q);
            System.Console.WriteLine(path);


            PathStorage.Save(path, "firstPath");
            System.Console.WriteLine(PathStorage.Load("firstPath"));
            System.Console.WriteLine(PathStorage.Load("somePath"));
        }
    }
}
    