using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Course : ICommentable
    {
        private string comment;
        private List<Teacher> teachers;
        private string name;


        public Course(string name)
        {
            this.Name = name;
            this.teachers = new List<Teacher>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public string Comment
        {
            get
            {
                if(String.IsNullOrWhiteSpace(this.comment))
                {
                    return "No comments yet!";
                }

                return this.comment;
            }
            set { this.comment = value; }
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public List<Teacher> GetTeachers()
        {
            return new List<Teacher>(this.teachers);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
