namespace State.States
{
    class InHomeState : IPawnState
    {
        private const int PointsNeededToChangeState = 6;

        public InHomeState(Pawn pawn)
        {
            this.Pawn = pawn;
            this.Pawn.BoardPosition = 0;
        }

        public Pawn Pawn { get; set; }

        public void ExecuteTurn(int dicePoints)
        {
            if (dicePoints == PointsNeededToChangeState)
            {
                this.Pawn.State = new OnBoardState(this.Pawn);
            }
        }
    }
}
