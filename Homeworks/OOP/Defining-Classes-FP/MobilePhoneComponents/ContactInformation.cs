
namespace MobilePhoneComponents
{
    using System;
    public class ContactInformation
    {
        private string name;
        private string phone;

        public ContactInformation(string name, string phoneNumber)
            : base()
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get
            {
                if (this.name.Equals(null))
                {
                    throw new NullReferenceException();
                }

                return this.name;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("contact name");
                }

                this.name = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                if (this.phone.Equals(null))
                {
                    throw new NullReferenceException();
                }

                return this.phone;
            }

            private set
            {
                if (!NumberIsValid(value))
                {
                    throw new ArgumentException("phone number");
                }

                this.phone = value;
            }
        }

        private bool NumberIsValid(string phoneNumber)
        {
            foreach (var letter in phoneNumber)
            {
                if (!Char.IsDigit(letter) && letter != '+' && letter != '/' && letter != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return String.Format("{0}({1})", this.Name, this.PhoneNumber);
        }
    }
}
