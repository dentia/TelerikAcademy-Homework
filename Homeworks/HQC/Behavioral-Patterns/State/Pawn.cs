namespace State
{
    using States;

    public class Pawn
    {
        public Pawn(string signature)
        {
            this.Signature = signature;
            this.State = new InHomeState(this);
        }

        public int BoardPosition { get; set; }

        public IPawnState State { get; set; }

        public string Signature { get; set; }

        public void ExecuteTurn(int dicePoints)
        {
            this.State.ExecuteTurn(dicePoints);
        }

        public bool HasReachedPosition(int position)
        {
            return this.BoardPosition >= position;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - pos: {2}", 
                this.Signature, this.State.GetType().Name, this.BoardPosition);
        }
    }
}
