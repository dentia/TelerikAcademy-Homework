namespace CompanyArticles
{
    using System;

    public struct Article : IComparable<Article>
    {
        public Article(string barcode, string vendor, decimal price)
            : this()
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Price = price;
        }

        public decimal Price { get; set; }

        public string Vendor { get; set; }

        public string Barcode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.Barcode, this.Vendor, this.Price);
        }

        public int CompareTo(Article other)
        {
            return string.Compare(this.Barcode, other.Barcode, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            var hash = 17;

            hash = (hash * 23) + this.Barcode.GetHashCode();
            hash = (hash * 23) + this.Vendor.GetHashCode();
            hash = (hash * 23) + this.Price.GetHashCode();

            return hash;
        }
    }
}
