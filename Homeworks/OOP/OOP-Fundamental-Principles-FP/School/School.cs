using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class School
    {
        private List<Course> courses;
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }

        public List<Course> GetCourses()
        {
            return new List<Course>(this.courses);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
