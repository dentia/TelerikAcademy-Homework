namespace ChainOfResponsibility.Cards
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
    }
}
