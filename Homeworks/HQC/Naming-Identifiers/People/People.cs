namespace People
{
    using System;

    public class People
    {
        public static void Main()
        {
            var female = new Person();
            female = female.ConfigurePerson(25);
            var male = new Person();
            male = male.ConfigurePerson(26);

            Console.WriteLine(female);
            Console.WriteLine(male);
        }
    }
}
