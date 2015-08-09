
namespace StudentsAndWorkers
{
    class Worker : Human
    {
        private double weekSalary;

        public double WeekSalary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }

        public Worker(string firstName, string lastName, double weekSalary)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
        }

        public double MoneyPerHour()
        {
            return this.WeekSalary / (5 * 8); // five work days * 8 work hours
        }

        public override string ToString()
        {
            return string.Format("{0} - {1:F3}", base.ToString(), this.MoneyPerHour());
        }
    }
}
