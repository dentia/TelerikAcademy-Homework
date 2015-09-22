namespace Sepcification.LogicSpecifications
{
    using System;

    public class NotSpecification<TSpec> : ISpecification<TSpec>
    {
        private readonly ISpecification<TSpec> specification;

        public NotSpecification(ISpecification<TSpec> spec)
        {
            if (spec == null)
            {
                throw new ArgumentNullException("spec");
            }

            this.specification = spec;
        }

        public bool IsSatisfiedBy(TSpec candidate)
        {
            return !this.specification.IsSatisfiedBy(candidate);
        }
    }
}
