
namespace Student
{
    public class Group
    {
        private string department;
        private string grNum;
        public Group(string department, string groupNumber)
        {
            this.Department = department;
            this.GroupNumber = groupNumber;
        }

        public string Department
        {
            get
            {
                return this.department;
            }
            set 
            {
                this.department = value;
            }
        }
        public string GroupNumber
        {
            get
            {
                return this.grNum;
            }
            set
            {
                this.grNum = value;
            }
        }
    }
}
