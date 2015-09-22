namespace Sepcification.ConcreteSpecifications
{
    using Cards;

    public class AceCardSpecification : ISpecification<Card>
    {
        public bool IsSatisfiedBy(Card card)
        {
            return ((int)card.Rank == 1);
        }
    }
}
