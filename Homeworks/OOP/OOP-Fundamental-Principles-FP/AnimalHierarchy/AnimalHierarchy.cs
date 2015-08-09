//Create a hierarchy Dog, Frog, Cat, Kitten, 
//Tomcat and define useful constructors and methods. 
//Dogs, frogs and cats are Animals. All animals can 
//produce sound (specified by the ISound interface). 
//Kittens and tomcats are cats. All animals are described 
//by age, name and sex. Kittens can be only female and tomcats 
//can be only male. Each animal produces a specific sound.
//Create arrays of different kinds of animals and calculate 
//the average age of each kind of animal using a static method (you may use LINQ).

namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    class AnimalHierarchy
    {
        static void Main(string[] args)
        {
            Kitten kit = new Kitten("Kitty", 2);
            Tomcat tom = new Tomcat("Tom", 3);
            Frog leggy = new Frog("Leggy", 6, Gender.Male);
            Dog rex = new Dog("Rex", 4, Gender.Male);
            Cat snow = new Cat("Snow", 5, Gender.Female);

            List<Animal> animals = new List<Animal>() { kit, tom, leggy, rex, snow };
            IntroduceAnimal(animals);

            Kitten[] kittens = new Kitten[] { kit, new Kitten("Lilly", 1), new Kitten("Smurf", 2) };
            Tomcat[] tomcats = new Tomcat[] { tom, new Tomcat("Joefrrey", 3), new Tomcat("Steve", 2), new Tomcat("Paul", 1) };
            Frog[] frogs = new Frog[] { leggy, new Frog("Squirrle", 12, Gender.Female), new Frog("Kurt", 1, Gender.Male) };
            Dog[] dogs = new Dog[] { rex, new Dog("Fluffy", 4, Gender.Female), new Dog("Olde Doge", 12, Gender.Male) };
            Cat[] cats = new Cat[] { snow };

            Console.WriteLine("Kittens: {0:F2}", Animal.AverageAge(kittens));
            Console.WriteLine("Tomcats: {0:F2}", Animal.AverageAge(tomcats));
            Console.WriteLine("Frogs: {0:F2}", Animal.AverageAge(frogs));
            Console.WriteLine("Dogs: {0:F2}", Animal.AverageAge(dogs));
            Console.WriteLine("Cats: {0:F2}", Animal.AverageAge(cats));
        }

        private static void IntroduceAnimal(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
