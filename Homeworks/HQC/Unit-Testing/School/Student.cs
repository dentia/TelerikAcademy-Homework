namespace School
{
    using System;

    public class Student
    {
        private const int MinValidIdValue = 10000;
        private const int MaxValidIdValue = 99999;
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
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
                    throw new ArgumentNullException("student name", "Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if (!Validator.IdIsInRange(value, Student.MinValidIdValue, Student.MaxValidIdValue))
                {
                    throw new ArgumentException(string.Format("Student ID must be in range [{0}; {1}]", Student.MinValidIdValue, Student.MaxValidIdValue), "Student ID");
                }

                this.id = value;
            }
        }

        public void AttendCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "Course cannot be null.");
            }

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "Course cannot be null.");
            }

            course.RemoveStudent(this);
        }
    }
}
