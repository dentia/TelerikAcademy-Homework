namespace Sepcification.LogicSpecifications
{
    public static class ExtensionMethods
    {
        public static ISpecification<TSpec> And<TSpec>(this ISpecification<TSpec> spec1, ISpecification<TSpec> spec2)
        {
            return new AndSpecification<TSpec>(spec1, spec2);
        }

        public static ISpecification<TSpec> Or<TSpec>(this ISpecification<TSpec> spec1, ISpecification<TSpec> spec2)
        {
            return new OrSpecification<TSpec>(spec1, spec2);
        }

        public static ISpecification<TSpec> Not<TSpec>(this ISpecification<TSpec> spec)
        {
            return new NotSpecification<TSpec>(spec);
        }
    }
}
