using System.Collections.Generic;

namespace Sepcification.Cards
{
    public class Deck
    {
        private readonly List<Card> cards;

        public Deck()
        {
            this.cards = new List<Card>();

            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 1; rank < 14; rank++)
                {
                    this.cards.Add(new Card((Suit)suit, (Rank)rank));
                }
            }
        }

        public List<Card> Cards
        {
            get { return new List<Card>(this.cards); }
        }

    }
}
