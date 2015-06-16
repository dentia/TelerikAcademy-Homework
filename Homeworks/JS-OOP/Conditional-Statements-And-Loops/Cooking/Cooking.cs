namespace Cooking
{
    public class Cooking
    {
        public static void Main()
        {
            var chef = new Chef();
            var bowl = chef.Cook();
            System.Console.WriteLine(bowl);
        }
    }
}
