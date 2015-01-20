
namespace Combinatorics
{
    using System.Text;
    public class Combination
    {
        private int length;
        private StringBuilder allCombinations;
        public Combination(int length)
        {
            allCombinations = new StringBuilder();
            this.length = length;
        }

        public string GetAllCombinations(int range)
        {
            int[] array = new int[length];
            GenerateCombinations(array, 0, 1, range);
            return allCombinations.ToString();
        }
        public void GenerateCombinations(int[] array, int currentIndex, int startNum, int range)
        {
            if (currentIndex == array.Length)
            {
                allCombinations.AppendLine(string.Format("{0}{1}{2}", "{", string.Join(", ", array), "}"));
                return;
            }
            else
            {
                for (int number = startNum; number <= range; number++)
                {
                    array[currentIndex] = number;
                    GenerateCombinations(array, currentIndex + 1, number + 1, range);
                }
            }
        }
    }
}
