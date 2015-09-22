namespace Visitor.Visitors
{
    public class Stalker : IVisitor
    {
        public void Visit(SocialMediaProfile profile)
        {
            profile.Views += 350;
            profile.Likes += 1;
        }
    }
}
