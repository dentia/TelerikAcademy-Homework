
namespace Combinatorics
{
    using System.Text;
    public class Variation
    {
        private int length;
        private StringBuilder allVariations;

        public Variation(int length)
        {
            allVariations = new StringBuilder();
            this.length = length;
        }

        public string GetAllVariations(int range)
        {
            int[] array = new int[length];
            GenerateVariations(array, 0, range);
            return allVariations.ToString();
        }

        private void GenerateVariations(int[] array, int currentIndex, int range)
        {
            if (currentIndex == array.Length)
            {
                allVariations.AppendLine(string.Format("{0}{1}{2}", "{", string.Join(", ", array), "}"));
                return;
            }

            for (int number = 1; number <= range; number++)
            {
                array[currentIndex] = number;
                GenerateVariations(array, currentIndex + 1, range);
            }
        }
    }
}
