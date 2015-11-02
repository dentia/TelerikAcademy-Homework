namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CourseIntance")]
    public class Course
    {
        public Course()
        {
            this.Id = Guid.NewGuid();
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }

        public Guid Id { get; set; }

        [Column("CourseName")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
