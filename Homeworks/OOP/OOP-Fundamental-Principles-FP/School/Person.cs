
namespace School
{
    using System;
    public abstract class Person : ICommentable
    {
        private string name;
        private string comment;
        public string Name
        {
            get { return name; }
            set 
            {
                ValidateName(value);

                name = value; 
            }
        }

        private void ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException();
            }

            foreach (var letter in name)
            {
                if (!Char.IsLetter(letter) && letter != ' ' && letter != '-')
                {
                    throw new ArgumentException();
                }
            }
        }

        public Person(string name)
        {
            this.Name = name;
        }


        public string Comment
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this.comment))
                {
                    return "No comment yet!";
                }

                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }
    }
}
