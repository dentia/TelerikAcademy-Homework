using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Teacher : Person, ICommentable
    {
        private List<Disciple> disciplines;

        public Teacher(string name, IEnumerable<Disciple> disciplines)
            : base(name)
        {
            this.disciplines = disciplines.ToList();
        }

        public List<Disciple> GetDisciplines()
        {
            return new List<Disciple>(this.disciplines);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
