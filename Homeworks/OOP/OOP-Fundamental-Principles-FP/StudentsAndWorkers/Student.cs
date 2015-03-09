
namespace StudentsAndWorkers
{
    class Student : Human
    {
        private double grade;

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1:F2}", base.ToString(), this.Grade);
        }
    }
}
