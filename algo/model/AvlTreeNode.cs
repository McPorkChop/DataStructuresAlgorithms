using System;

namespace algo.model
{
    /// <summary>
    ///     Avl树结点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AvlTreeNode<T> : BinaryTreeNode<T> where T : IComparable
    {
        public AvlTreeNode(T data) : base(data)
        {
        }

        public new AvlTreeNode<T>? Parent
        {
            get => (AvlTreeNode<T>?)base.Parent;
            set => base.Parent = value;
        }

        public new AvlTreeNode<T>? Left
        {
            get => (AvlTreeNode<T>?)base.Left;
            set => base.Left = value;
        }

        public new AvlTreeNode<T>? Right
        {
            get => (AvlTreeNode<T>?)base.Right;
            set => base.Right = value;
        }

        /// <summary>
        ///     平衡值
        /// </summary>
        public int Balance { get; set; }
    }
}