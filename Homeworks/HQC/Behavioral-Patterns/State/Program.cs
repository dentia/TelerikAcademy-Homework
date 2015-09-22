namespace State
{
    using System;

    class Program
    {
        private static readonly Random dice = new Random();
        private const int MaxDicePoints = 6;
        private const int FinalCell = 30;

        static void Main()
        {
            var pawnA = new Pawn("A");
            var pawnB = new Pawn("B");

            while (true)
            {
                ExecuteTurn(pawnA);
                ExecuteTurn(pawnB);
            }
        }

        static int RollDice()
        {
            return dice.Next(1, MaxDicePoints + 1);
        }

        static void ExecuteTurn(Pawn pawn)
        {
            int dicePoints;

            do
            {
                dicePoints = RollDice();

                pawn.ExecuteTurn(dicePoints);
                Console.WriteLine(pawn);

                if (pawn.HasReachedPosition(FinalCell))
                {
                    Console.WriteLine("{0} won", pawn.Signature);
                    Environment.Exit(0);
                }

            } while (dicePoints == MaxDicePoints);
        }
    }
}
