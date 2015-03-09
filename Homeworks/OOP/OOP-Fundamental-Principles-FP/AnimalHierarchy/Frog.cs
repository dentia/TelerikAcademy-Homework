
namespace AnimalHierarchy
{
    using System;
    public class Frog : Animal
    { 
        public Frog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
            this.Type = AnimalType.Frog;
        }

        public override string MakeSound()
        {
            return "Ribbit - ribbit!";
        }
    }
}
