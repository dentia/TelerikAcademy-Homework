namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsCount = 30;
        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (Validator.StringIsInvalid(value))
                {
                    throw new ArgumentNullException("course name", "Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Student cannot be null.");
            }

            if (this.Students.Count + 1 > Course.MaxStudentsCount)
            {
                throw new InvalidOperationException("Student list is full.");
            }

            if (this.students.Contains(student))
            {
                throw new InvalidOperationException("This student already has joined the class.");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Student cannot be null.");
            }

            if (!this.students.Contains(student))
            {
                throw new InvalidOperationException("The student does not attend this class.");
            }

            this.students.Remove(student);
        }
    }
}
