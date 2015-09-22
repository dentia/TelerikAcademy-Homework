namespace State.States
{
    using System.Linq;

    public class OnBoardState : IPawnState
    {
        private readonly int[] fatalFields = new int[] {6, 13, 29};

        public OnBoardState(Pawn pawn)
        {
            this.Pawn = pawn;
            this.Pawn.BoardPosition = 1;
        }

        public Pawn Pawn { get; set; }

        public void ExecuteTurn(int dicePoints)
        {
            this.Pawn.BoardPosition += dicePoints;

            if (fatalFields.Any(x => x == this.Pawn.BoardPosition))
            {
                this.Pawn.State = new InHomeState(this.Pawn);
            }
        }
    }
}
