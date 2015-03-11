
namespace Student
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Text.RegularExpressions;
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private MailAddress email;
        private List<double> marks;
        private string phone;
        private string facultyNumber;
        private Group group;

        public Student(string firstName, string lastName, int age, string tel, string email, string facultyNumber, Group group)
        {
            this.marks = new List<double>();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = tel;
            this.Email = new MailAddress(email);
            this.FacultyNumber = facultyNumber;
            this.Age = age;
            this.AttendedGroup = group;
        }

        #region properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                CheckName(value);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                CheckName(value);

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                CheckAge(value);

                this.age = value;
            }
        }

        public MailAddress Email
        {
            get
            {
                return this.email;
            }
            set
            {
                CheckEmail(value.Address);

                this.email = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                CheckPhone(value);

                this.phone = value;
            }
        }
        
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                this.facultyNumber = value;
            }
        }

        public Group AttendedGroup
        {
            get
            {
                return this.group;
            }
            set
            {
                this.group = value;
            }
        }

        public List<double> Marks
        {
            get
            {
                return new List<double>(this.marks);
            }
        }
        #endregion

        #region valdate_input
        private void CheckName(string name)
        {
            foreach (var letter in name)
            {
                if (!Char.IsLetter(letter) && letter != ' ' && letter != '-')
                {
                    throw new ArgumentException("Invalid name!");
                }
            }
        }

        private void CheckAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException("Invalid age!");
            }

            if (age < 14)
            {
                throw new ArgumentException("The student is too young!");
            }

            if (age > 150)
            {
                throw new ArgumentException();
            }
        }

        private void CheckEmail(string email)
        {
            if( !Regex.IsMatch(email.Trim(),
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                throw new ArgumentException("Invalid email!");
            }
        }

        private void CheckPhone(string phone)
        {
            if (!Regex.IsMatch(phone.Trim(), @"\+?[()\d- ]+"))
            {
                throw new ArgumentException("Invalid phone!");
            }
        }
        #endregion

        public void AddMark(double grade)
        {
            this.marks.Add(grade);
        }

        public void AddMarks(params double[] marks)
        {
            this.marks.AddRange(marks);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
