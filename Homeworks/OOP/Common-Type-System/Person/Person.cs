
namespace Person
{
    using System;
    class Person
    {
        private int? age;
        private string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, int age)
            : this(name)
        {
            this.Age = age;
        }

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return String.Format("{0}, Age: {1}", this.Name, this.Age == null ? "Unknown" : this.Age.ToString());
        }
    }
}
