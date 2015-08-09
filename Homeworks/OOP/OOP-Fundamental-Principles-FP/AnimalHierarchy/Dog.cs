
namespace AnimalHierarchy
{
    using System;
    public class Dog : Animal
    {
        public Dog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
            this.Type = AnimalType.Dog;
        }

        public override string MakeSound()
        {
            return "Wuff - wuff!";
        }
    }
}
