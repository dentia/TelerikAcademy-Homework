using System;

namespace Sepcification.LogicSpecifications
{
    using System;

    public class OrSpecification<TSpec> : ISpecification<TSpec>
    {
        private readonly ISpecification<TSpec> specification1;
        private readonly ISpecification<TSpec> specification2;

        public OrSpecification(ISpecification<TSpec> specification1, ISpecification<TSpec> specification2)
        {
            if (specification1 == null)
            {
                throw new ArgumentNullException("spec1");
            }

            if (specification2 == null)
            {
                throw new ArgumentNullException("spec2");
            }

            this.specification1 = specification1;
            this.specification2 = specification2;
        }

        public bool IsSatisfiedBy(TSpec specification)
        {
            return this.specification1.IsSatisfiedBy(specification) ||
                this.specification2.IsSatisfiedBy(specification);
        }
    }
}

