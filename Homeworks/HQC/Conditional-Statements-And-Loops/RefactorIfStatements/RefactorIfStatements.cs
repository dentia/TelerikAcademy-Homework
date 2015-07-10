namespace RefactorIfStatements
{
    using Cooking.ToolsAndIngredients;

    public class RefactorIfStatements
    {
        public static void Main()
        {
            /*
            Potato potato;
            //...
            if (potato != null)
            if(!potato.HasNotBeenPeeled && !potato.IsRotten)
            Cook(potato);
            */
            Potato potato = new Potato();

            // ....
            if (potato != null)
            {
                bool notPeeled = !potato.IsPeeled;
                bool notRotten = !potato.IsRotten;

                if (notPeeled && notRotten)
                {
                    potato.Cook();
                }
            }

            /*
            if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y &&
            MIN_Y <= y) && !shouldNotVisitCell)))
            {
                VisitCell();
            }
            */
            const int MinX = 5;
            const int MaxX = 15;
            const int MinY = 5;
            const int MaxY = 15;

            int x = 7;
            int y = 8;

            bool shouldVisitCell = true;

            if (shouldVisitCell && IsInRange(x, MinX, MaxX) && IsInRange(y, MinY, MaxY))
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
            System.Console.WriteLine("Visited");
        }

        public static bool IsInRange(int value, int min, int max)
        {
            bool isInRange = value >= min && value <= max;

            return isInRange;
        }
    }
}
