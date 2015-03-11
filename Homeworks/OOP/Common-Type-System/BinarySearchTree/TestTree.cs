using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class TestTree
    {
        static void Main()
        {
            Tree<int> tree = new Tree<int>(10);

            for (int i = 0; i < 20; i++)
            {
                if (i == 10) i++;
                tree.Add(i);
            }

            Console.WriteLine(tree);
            Console.WriteLine(tree.HasValue(15));
            Console.WriteLine(tree.HasValue(25));

            tree.Add(25);
            Console.WriteLine(tree);
            Console.WriteLine(tree.HasValue(25));

        }
    }
}
