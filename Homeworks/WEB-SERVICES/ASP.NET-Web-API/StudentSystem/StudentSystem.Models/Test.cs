namespace StudentSystem.Models
{
    using System;
using System.Collections.Generic;

    public class Test
    {
        public Test()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
