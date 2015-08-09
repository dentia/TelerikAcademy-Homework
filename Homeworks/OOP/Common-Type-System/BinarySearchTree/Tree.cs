
namespace BinarySearchTree
{
    using System;
    using System.Text;
    class Tree<T>
        where T : IComparable
    {
        public Node<T> Root;

        public Tree(T initial)
        {
            this.Root = new Node<T>(initial);
        }

        public void Add(T value)
        {
            AddRecursive(ref this.Root, ref this.Root, value);
        }

        private void AddRecursive(ref Node<T> N, ref Node<T> parent, T value)
        {
            if (N == null)
            {
                Node<T> newNode = new Node<T>(value);
                newNode.Parent = parent;
                N = newNode;
                return;
            }

            if (value.CompareTo(N.Value) < 0)
            {
                AddRecursive(ref N.Left, ref N, value);
                return;
            }

            if (value.CompareTo(N.Value) >= 0)
            {
                AddRecursive(ref N.Right, ref N, value);
                return;
            }
        }

        public bool HasValue(T N)
        {
            return Find(this.Root, N);
        }

        private bool Find(Node<T> node, T N)
        {
            if (node == null) return false;
            if (node.Value.Equals(N)) return true;

            if (N.CompareTo(node.Value) < 0) return Find(node.Left, N);
            if (N.CompareTo(node.Value) >= 0) return Find(node.Right, N);

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Print(null, ref result);

            return result.ToString().Trim().Trim(',');
        }

        private void Print(Node<T> N, ref StringBuilder result)
        {
            if (N == null)
            {
                N = this.Root;
            }

            if (N.Left != null)
            {
                Print(N.Left, ref result);
                result.Append(N + ", ");
            }
            else
            {
                result.Append(N + ", ");
            }

            if (N.Right != null)
            {
                Print(N.Right, ref result);
            }
        }
    }
}
