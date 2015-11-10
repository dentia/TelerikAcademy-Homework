namespace Trie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ET.FakeText;

    public class Startup
    {
        public static void Main()
        {
            var generator = new TextGenerator(WordTypes.Name);

            var names = generator.GenerateText(1000);
            var trie = new Trie();
            var words = new HashSet<string>();
            names.Split(' ').ToList().ForEach(
                x =>
                    {
                        words.Add(x);
                        trie.AddWord(x);
                    });

            var result = new StringBuilder();

            foreach (var word in words.OrderBy(x => x))
            {
                int occurenceCount;
                trie.TryFindWord(word, out occurenceCount);
                result.AppendFormat("{0} -> {1} times", word, occurenceCount).AppendLine();
            }

            Console.WriteLine(result);
        }
    }
}
