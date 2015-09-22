namespace Visitor.Visitors
{
    public class Creeper : IVisitor
    {
        public void Visit(SocialMediaProfile profile)
        {
            profile.Views += 100;
            profile.Likes += 100;
        }
    }
}
