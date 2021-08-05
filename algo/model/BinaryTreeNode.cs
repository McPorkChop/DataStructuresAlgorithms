using System;
namespace algo.model
{
    public class BinaryTreeNode<T> : TreeNode<T>
    {


        public BinaryTreeNode(T value) : base(value, 2) { }

        /// <summary>
        /// 左子数
        /// </summary>
        public BinaryTreeNode<T>? left
        {
            get => children[0] as BinaryTreeNode<T>;
            set
            {
                children[0] = value;
            }
        }

        /// <summary>
        /// 右子树
        /// </summary>
        public BinaryTreeNode<T>? right
        {
            get => children[1] as BinaryTreeNode<T>;
            set
            {
                children[1] = value;
            }
        }
    }
}
