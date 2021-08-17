using System;

namespace algo.model
{
    public class BinaryTreeNode<T> : TreeNode<T>, IComparable<BinaryTreeNode<T>> where T : IComparable
    {
        public BinaryTreeNode(T data, BinaryTreeNode<T>? parent = null)
        {
            Parent = parent;
            Data = data;
        }

        /// <summary>
        ///     父结点
        /// </summary>
        public BinaryTreeNode<T>? Parent { get; set; }

        /// <summary>
        ///     左结点
        /// </summary>
        public BinaryTreeNode<T>? Left { get; set; }

        /// <summary>
        ///     右结点
        /// </summary>
        public BinaryTreeNode<T>? Right { get; set; }

        public new BinaryTreeNode<T>?[] Children
        {
            get { return new[] { Left, Right }; }
        }

        public int CompareTo(BinaryTreeNode<T>? other)
        {
            if (other == null) return -1;
            return Data.CompareTo(other.Data);
        }
    }
}