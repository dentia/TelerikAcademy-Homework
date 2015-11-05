namespace Phones
{
    public class Entry
    {
        public Entry(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name { get; set; }

        public string Town { get; set; }

        public string Phone { get; set; }

        public override bool Equals(object obj)
        {
            var otherEntry = obj as Entry;

            if (otherEntry == null)
            {
                return this == null;
            }

            return this.Name == otherEntry.Name &&
                    this.Town == otherEntry.Town &&
                    this.Phone == otherEntry.Phone;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Town.GetHashCode() ^ this.Phone.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.Name, this.Town, this.Phone);
        }
    }
}
