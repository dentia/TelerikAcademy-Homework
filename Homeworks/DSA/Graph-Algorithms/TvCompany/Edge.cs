namespace TvCompany
{
    using System;

    public class Edge : IComparable<Edge>
    {
        public Edge(int from, int to, int cost)
        {
            this.From = from;
            this.To = to;
            this.Cost = cost;
        }

        public int From { get; set; }

        public int To { get; set; }

        public int Cost { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Cost.CompareTo(other.Cost);
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1} ({2})", this.From, this.To, this.Cost);
        }
    }
}
