
namespace Person
{
    using System;
    class TestPerson
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Niki", 24);
            Person p2 = new Person("Ivo");

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}
