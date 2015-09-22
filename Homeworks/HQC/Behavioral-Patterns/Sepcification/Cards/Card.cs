namespace Sepcification.Cards
{ 
    public class Card
    {
        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public override string ToString()
        {
            return string.Format("{0} of {1}", this.Rank, this.Suit);
        }
    }
}
