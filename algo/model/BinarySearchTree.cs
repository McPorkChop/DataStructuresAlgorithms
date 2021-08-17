using System;

namespace algo.model
{
    /// <summary>
    ///     二叉搜索树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TNode"></typeparam>
    public class BinarySearchTree<T, TNode> : BinaryTree<T, TNode>
        where T : IComparable
        where TNode : BinaryTreeNode<T>
    {
        /// <summary>
        ///     插入新结点
        /// </summary>
        /// <param name="value">结点值</param>
        public TNode? Insert(T value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(value) as TNode;
                return Root;
            }

            var node = new BinaryTreeNode<T>(value);
            return RecursiveInsert(Root, node);
        }

        /// <summary>
        ///     递归执行插入操作
        /// </summary>
        /// <param name="root">根结点</param>
        /// <param name="node">新结点</param>
        /// <returns></returns>
        private TNode? RecursiveInsert(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {
            var rootCompare = node.Data.CompareTo(root.Data);
            switch (rootCompare)
            {
                case > 0 when root.Right == null:
                    root.Right = node;
                    node.Parent = root;
                    return node as TNode;
                case > 0:
                    return RecursiveInsert(root.Right, node);
                case < 0 when root.Left == null:
                    root.Left = node;
                    node.Parent = root;
                    return node as TNode;
                case < 0:
                    return RecursiveInsert(root.Left, node);
            }

            return null;
        }

        /// <summary>
        ///     删除结点
        /// </summary>
        /// <param name="value">结点值</param>
        public bool Remove(T value)
        {
            if (Root == null) return false;
            if (Root.Data.CompareTo(value) == 0)
            {
                Root = null;
                return true;
            }

            var root = Root;
            while (root != null)
            {
                var compare = root.Data.CompareTo(value);
                switch (compare)
                {
                    case >0:
                        if (root.Right == null) return false;
                        if (root.Right.Data.CompareTo(value) == 0)
                        {
                            root.Right = RemoveRoot(root);
                            return true;
                        }

                        root = root.Right as TNode;
                        break;
                    case <0:
                        if (root.Left == null) return false;
                        if (root.Left.Data.CompareTo(value) == 0)
                        {
                            root.Left = RemoveRoot(root);
                            return true;
                        }

                        root = root.Left as TNode;
                        break;
                    default:
                        root = root.Left as TNode;
                        break;
                }
            }

            return false;
        }

        /// <summary>
        ///     查找结点
        /// </summary>
        /// <param name="value">结点值</param>
        /// <returns>结点</returns>
        public BinaryTreeNode<T>? Find(T value)
        {
            var root = Root;
            while (root != null)
            {
                var compare = root.Data.CompareTo(value);
                switch (compare)
                {
                    case >0:
                        root = root.Right as TNode;
                        break;
                    case <0:
                        root = root.Left as TNode;
                        break;
                    default:
                        return root;
                }
            }

            return null;
        }

        /// <summary>
        ///     删除根结点
        /// </summary>
        /// <param name="root">根结点</param>
        /// <returns>新根结点</returns>
        private BinaryTreeNode<T>? RemoveRoot(BinaryTreeNode<T> root)
        {
            if (root.Left == null || root.Right == null) return null;
            if (root.Left == null) return root.Right;
            if (root.Right == null) return root.Left;
            BinaryTreeNode<T>? prev = null;
            BinaryTreeNode<T> last = root.Left;
            while (last.Right != null)
            {
                prev = last;
                last = last.Right;
            }

            if (prev != null)
                prev.Right = last.Left;
            last.Left = root.Left;
            last.Right = root.Right;
            last.Parent = root.Parent;
            return last;
        }
    }
}