
namespace Combinatorics
{
    using System.Collections.Generic;
    using System.Text;
    public class Permutation
    {
        private int length;
        private int range;
        StringBuilder permutations;

        public Permutation(int length)
        {
            this.length = length;
            this.range = length;
            this.permutations = new StringBuilder();
        }

        public string GetAllPermutations()
        {
            int[] temp = new int[this.length];
            bool[] used = new bool[this.length];
            Permute(temp, used, 0);

            return this.permutations.ToString();
        }

        private void Permute(int[] array, bool[] used, int currentIndex)
        {
            if (currentIndex == array.Length)
            {
                this.permutations.AppendLine(string.Format("{0}{1}{2}", "{", string.Join(", ", array), "}"));
                return;
            }

            for (int number = 1; number <= range; number++)
            {
                if (!used[number - 1])
                {
                    used[number - 1] = true;
                    array[currentIndex] = number;
                    Permute(array, used, currentIndex + 1);
                    used[number - 1] = false;
                }
            }
        }
    }
}
