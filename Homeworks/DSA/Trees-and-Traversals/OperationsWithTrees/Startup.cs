namespace OperationsWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        public static void Main()
        {
            var tree = ReadTree();
            
            Console.WriteLine("Root: " + tree.GetRoot());
            Console.WriteLine("Leaves: " + string.Join(", ", tree.GetLeaves()));
            Console.WriteLine("Middle nodes: " + string.Join(", ", tree.GetMiddleNodes()));
            Console.WriteLine("Number of levels: " + (GetLongestPath(tree.GetRoot()) + 1));

            var sumForPaths = 5;
            var paths = tree.GetPathsWithSum(sumForPaths);
            Console.WriteLine("Paths with sum {0}:", sumForPaths);
            paths
                .Select(path => "[" + string.Join(" -> ", path.Reverse()) + "]")
                .ToList()
                .ForEach(x =>
                    {
                        Console.WriteLine("\t" + x);
                    });

            var sumForSubtrees = 21;
            var nodes = tree.GetTreesWithSum(sumForSubtrees);
            Console.WriteLine("Roots of subtrees with sum {0}: {1}", sumForSubtrees, string.Join(", ", nodes));
        }

        public static List<TreeNode<int>> GetTreesWithSum(this List<TreeNode<int>> nodes, int sum)
        {
            var result = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.GetSubSum() == sum)
                {
                    result.Add(node);
                }
            }

            return result; 
        }

        public static List<TreeNode<int>[]> GetPathsWithSum(this List<TreeNode<int>> nodes, int sum)
        {
            List<TreeNode<int>[]> paths = new List<TreeNode<int>[]>();
            foreach (var node in nodes)
            {
                GetPathsFromNode(node, new Stack<TreeNode<int>>(), paths);
            }

            return paths.Where(path => path.Sum(node => node.Value) == sum).ToList();
        }

        public static void GetPathsFromNode(TreeNode<int> node, Stack<TreeNode<int>> stack, List<TreeNode<int>[]> paths)
        {
            stack.Push(node);
            paths.Add(stack.ToArray());

            foreach (var child in node.Children)
            {
                GetPathsFromNode(child, stack, paths);
            }

            stack.Pop();
        }

        public static List<TreeNode<int>> ReadTree()
        {
            var tree = new List<TreeNode<int>>();

            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount - 1; i++)
            {
                int[] values = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var parent = tree.GetNode(values[0]);
                var child = tree.GetNode(values[1]);

                parent.AddChildren(child);
            }

            return tree;
        }

        public static TreeNode<int> GetNode(this List<TreeNode<int>> tree, int value)
        {
            var node = tree.FirstOrDefault(n => value == n.Value);

            if (node == null)
            {
                node = new TreeNode<int>(value);
                tree.Add(node);
            }

            return node;
        }

        public static TreeNode<int> GetRoot(this List<TreeNode<int>> tree)
        {
            var orphans = tree.Where(n => !n.HasParent).ToList();

            if (orphans.Count() != 1)
            {
                throw new InvalidOperationException("Invalid tree.");
            }

            return orphans.First();
        }

        public static List<TreeNode<int>> GetLeaves(this List<TreeNode<int>> tree)
        {
            return tree.Where(n => !n.HasChildren).ToList();
        }

        public static List<TreeNode<int>> GetMiddleNodes(this List<TreeNode<int>> tree)
        {
            return tree.Where(n => n.HasChildren && n.HasParent).ToList();
        }

        public static int GetLongestPath(TreeNode<int> rootNode)
        {
            if (rootNode.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in rootNode.Children)
            {
                maxPath = Math.Max(maxPath, GetLongestPath(node));
            }

            return maxPath + 1;
        }
    }
}
