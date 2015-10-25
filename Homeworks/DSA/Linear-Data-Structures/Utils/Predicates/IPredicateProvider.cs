namespace Utils.Predicates
{
    using System;

    public interface IPredicateProvider
    {
        Predicate<string> ShouldStopReading { get; }

        Predicate<string> IsValidInteger { get; }

        Predicate<string> IsValidPositiveInteger { get; }
    }
}
