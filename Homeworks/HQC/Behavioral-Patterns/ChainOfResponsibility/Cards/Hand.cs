namespace ChainOfResponsibility.Cards
{
    using System.Collections.Generic;

    public class Hand
    {
        public Hand()
        {
            this.Cards = new List<Card>();   
        }

        public List<Card> Cards { get; private set; }

        public Hand AddCard(ChainOfResponsibility.Cards.Card card)
        {
            this.Cards.Add(card);

            return this;
        }

        public Hand Clear()
        {
            this.Cards.Clear();

            return this;
        }
    }
}
