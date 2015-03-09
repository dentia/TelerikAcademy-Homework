
namespace AnimalHierarchy
{
    using System;
    public class Cat : Animal
    {
        public Cat(string name, int age, Gender sex)
            : base(name, age, sex)
        {
            this.Type = AnimalType.Cat;
        }

        public override string MakeSound()
        {
            return "Mew - mew!";
        }
    }
}
