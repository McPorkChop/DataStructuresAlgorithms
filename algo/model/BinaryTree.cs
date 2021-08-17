using System;
using System.Collections.Generic;

namespace algo.model
{
    /// <summary>
    ///     二叉树接口
    /// </summary>
    public class BinaryTree<TValue, TNode> : Tree<TValue, TNode>
        where TValue : IComparable
        where TNode : BinaryTreeNode<TValue>
    {
        /// <summary>
        ///     中序遍历
        /// </summary>
        /// <returns></returns>
        public TValue[] InOrder()
        {
            return Root == null ? Array.Empty<TValue>() : InOrder(Root);
        }

        /// <summary>
        ///     中序遍历
        /// </summary>
        /// <returns></returns>
        private TValue[] InOrder(TNode? root)
        {
            if (root == null) return Array.Empty<TValue>();
            if (root.Children.Length < 1)
                return new[] { root.Data };
            var result = new List<TValue> { root.Data };
            result.InsertRange(0, InOrder(root.Left as TNode));
            result.AddRange(InOrder(root.Right as TNode));
            return result.ToArray();
        }
    }
}