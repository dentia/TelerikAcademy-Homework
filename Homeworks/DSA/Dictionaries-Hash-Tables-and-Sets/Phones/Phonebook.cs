namespace Phones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        private Dictionary<string, HashSet<Entry>> entries;

        public Phonebook()
        {
            this.entries = new Dictionary<string, HashSet<Entry>>();
        }

        public void Add(Entry entry)
        {
            var splittedNames = entry.Name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in splittedNames)
            {
                if (this.entries.ContainsKey(name))
                {
                    this.entries[name].Add(entry);
                }
                else
                {
                    this.entries.Add(name, new HashSet<Entry>() { entry });
                }
            }
        }

        public ICollection<Entry> Find(string name)
        {
            if (this.entries.ContainsKey(name))
            {
                return this.entries[name];
            }
            else
            {
                return new List<Entry>();
            }
        }

        public ICollection<Entry> Find(string name, string town)
        {
            return this.Find(name).Where(x => x.Town == town).ToList();
        }
    }
}
