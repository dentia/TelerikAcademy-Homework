
namespace PrintCompanyInfo
{
    using System;
    class Manager
    {
        private string managerFirstName;
        private string managerLastName;
        private int managerAge;
        private string managerPhone;

        public string FirstName { get { return this.managerFirstName; } set { this.managerFirstName = value; } }
        public string LastName { get { return this.managerLastName; } set { this.managerLastName = value; } }
        public int Age { get { return this.managerAge; } set { this.managerAge = value; } }
        public string Phone { get { return this.managerPhone; } set { this.managerPhone = value; } }

        public override string ToString()
        {
            return string.Format(@"
    MANAGER:
    {0} {1}, age: {3}
    Phone:  {2}
", this.FirstName, this.LastName, this.Phone, this.Age);
        }

        public void GetManagerInfo()
        {
            Console.Write("\nManager first name: ");
            this.FirstName = Console.ReadLine();
            Console.Write("Manager last name: ");
            this.LastName = Console.ReadLine();
            Console.Write("Manager age: ");
            this.Age = int.Parse(Console.ReadLine());
            Console.Write("Manager phone: ");
            this.Phone = Console.ReadLine();
        }
    }
}
