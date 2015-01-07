
namespace PrintCompanyInfo
{
    using System;
    class Company
    {
        private string companyName;
        private string companyAddress;
        private string comapanyPhone;
        private string companyFax;
        private string companyWebSite;
        private Manager manager;

        public Company()
        {
            this.ComanyManager = new Manager();
        }

        public string Name { get { return this.companyName; } set { this.companyName = value; } }
        public string Address { get { return this.companyAddress; } set { this.companyAddress = value; } }
        public string Phone { get { return this.comapanyPhone; } set { this.comapanyPhone = value; } }
        public string Fax { get { return this.companyFax; } set { this.companyFax = value; } }
        public string WebSite { get { return this.companyWebSite; } set { this.companyWebSite = value; } }
        public Manager ComanyManager { get { return this.manager; } set { this.manager = value; } }

        public override string ToString()
        {
            return string.Format(@"
{0}
Address:    {1}
Phone:      {2}
Fax number: {3}
Web site:   {4}
{5}
", this.Name, this.Address, this.Phone, 
 string.IsNullOrWhiteSpace(this.Fax) ? "(no fax)" : this.Fax, 
 this.WebSite, this.ComanyManager);
        }

        public void FillCompanyInfo()
        {
            Console.Write("Company name: ");
            this.Name = Console.ReadLine();
            Console.Write("Address: ");
            this.Address = Console.ReadLine();
            Console.Write("Phone: ");
            this.Phone = Console.ReadLine();
            Console.Write("Fax: ");
            this.Fax = Console.ReadLine();
            Console.Write("Web site: ");
            this.WebSite = Console.ReadLine();

            this.ComanyManager.GetManagerInfo();
        }
    }
}
