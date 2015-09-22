namespace Sepcification
{
    public interface ISpecification<in TSpec>
    {
        bool IsSatisfiedBy(TSpec entity);
    }
}
