namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private const string InvalidLabNameExceptionMessage = "Lab name cannot be null or empty.";
        private string lab;

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab 
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(LocalCourse.InvalidLabNameExceptionMessage);
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Lab = " + this.Lab);

            return result.ToString();
        }
    }
}
