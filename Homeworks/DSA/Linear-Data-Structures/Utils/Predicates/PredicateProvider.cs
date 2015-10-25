namespace Utils.Predicates
{
    using System;

    public class PredicateProvider : IPredicateProvider
    {
        public Predicate<string> ShouldStopReading
        {
            get
            {
                return string.IsNullOrWhiteSpace;
            }
        }

        public Predicate<string> IsValidInteger
        {
            get
            {
                return s =>
                    {
                        int checknumber;
                        return int.TryParse(s, out checknumber);
                    };
            }
        }

        public Predicate<string> IsValidPositiveInteger
        {
            get
            {
                return s =>
                    {
                        int checknumber;
                        return int.TryParse(s, out checknumber) && checknumber >= 0;
                    };
            }
        }

        public Predicate<string> IsValidIntegerTo1000
        {
            get
            {
                return s =>
                {
                    int checknumber;
                    return int.TryParse(s, out checknumber) && checknumber >= 0 && checknumber <= 1000;
                };
            }
        }
    }
}
