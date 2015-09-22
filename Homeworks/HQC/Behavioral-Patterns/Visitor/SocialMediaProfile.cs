namespace Visitor
{
    using Visitors;

    public class SocialMediaProfile
    {
        public SocialMediaProfile(string owner)
        {
            this.Owner = owner;
            this.Views = 0;
            this.Likes = 0;
        }

        public string Owner { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return string.Format("{0} - views: {1} - likes: {2}", this.Owner, this.Views, this.Likes);
        }
    }
}
