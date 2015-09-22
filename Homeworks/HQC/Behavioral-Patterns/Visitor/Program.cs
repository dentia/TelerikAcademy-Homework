namespace Visitor
{
    using System;

    using Visitors;

    class Program
    {
        static void Main()
        {
            var profile = new SocialMediaProfile("Niki");

            var creeper = new Creeper();
            profile.Accept(creeper);
            Console.WriteLine(profile);

            var stalker = new Stalker();
            profile.Accept(stalker);
            Console.WriteLine(profile);
        }
    }
}
