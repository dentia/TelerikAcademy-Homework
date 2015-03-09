
namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class Animal : ISound
    {
        public AnimalType Type { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Sex { get; set; }

        public Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.Type = AnimalType.Unknown;
        }

        public virtual string MakeSound()
        {
            return "Zzz.";
        }

        public override string ToString()
        {
            return String.Format("{0} I'm a {1} {2} - my name is {3} and I am {4} y.o.",
                this.MakeSound(), this.Sex, this.Type, this.Name, this.Age);
        }

        public static double AverageAge(IEnumerable<Animal> animals)
        {
            return animals.Average(x => x.Age);
        }
    }
}
