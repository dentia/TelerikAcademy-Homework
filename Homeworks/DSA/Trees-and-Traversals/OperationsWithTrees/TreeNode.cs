namespace OperationsWithTrees
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        private readonly IList<TreeNode<T>> children;

        public TreeNode(T value)
        { 
            this.children = new List<TreeNode<T>>();
            this.Value = value;
            this.HasParent = false;
        }

        public T Value { get; private set; }

        public IList<TreeNode<T>> Children
        {
            get
            {
                return this.children;
            }
        }

        public bool HasParent { get; set; }

        public bool HasChildren
        {
            get
            {
                return this.Children.Count > 0;
            }
        }

        public void AddChildren(params TreeNode<T>[] children)
        {
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.HasParent = true;
            }
        }

        public T GetSubSum()
        {
            dynamic sum = this.Value;

            foreach (var child in this.Children)
            {
                sum += child.GetSubSum();
            }

            return (T)sum;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
