
namespace LargestNumSmallerThanK
{
    using System.Collections.Generic;
    class NumberComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}
