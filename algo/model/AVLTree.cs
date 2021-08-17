using System;

namespace algo.model
{
    /// <summary>
    ///     Avl Tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AvlTree<T> : BinarySearchTree<T, AvlTreeNode<T>> where T : IComparable
    {
        /// <summary>
        ///     平衡因子
        /// </summary>
        public int[] BalanceFactor => new[] { -1, 0, 1 };

        /// <summary>
        ///     插入新结点
        /// </summary>
        /// <param name="value"></param>
        public new void Insert(T value)
        {
            var node = base.Insert(value);
            if (node == null) return;
            if (node.Left?.Data.CompareTo(value) == 0)
                node.Balance--;
            else
                node.Balance++;

            if (node.Balance == 0) return;
            Balance(node);
        }

        /// <summary>
        ///     左旋操作
        /// </summary>
        private void LeftRotate(AvlTreeNode<T> node)
        {
            var parent = node.Parent;
            if (node.Right is not AvlTreeNode<T> right) return;
            var rightLeft = right.Left;

            node.Right = rightLeft;

            right.Left = node;
            if (parent == null)
            {
                Root = right;
            }
            else
            {
                if (parent.Left == node)
                    parent.Left = right;
                else
                    parent.Right = right;
            }

            node.Balance = 0;
            right.Balance = 0;

            node = right;
        }

        /// <summary>
        ///     右旋操作
        /// </summary>
        private void RightRotate(AvlTreeNode<T> node)
        {
            var parent = node.Parent;
            if (node.Left is not AvlTreeNode<T> left) return;
            var leftRight = left.Right;

            left.Right = node;
            node.Left = leftRight;
            if (parent == null)
            {
                Root = left;
            }
            else
            {
                if (parent.Left == node)
                    parent.Left = left;
                else
                    parent.Right = left;
            }

            node.Balance = 0;
            left.Balance = 0;

            node = left;
        }

        /// <summary>
        ///     左右旋操作
        /// </summary>
        private void LeftRightRotate(AvlTreeNode<T> node)
        {
            if (node.Left is not AvlTreeNode<T> left) return;
            var leftRight = left.Right;

            var balance = leftRight?.Balance;

            LeftRotate(left);
            RightRotate(node);

            switch (balance)
            {
                case 1:
                    node.Balance = 0;
                    left.Balance = -1;
                    break;
                case -1:
                    node.Balance = 1;
                    left.Balance = 0;
                    break;
                default:
                    node.Balance = 0;
                    left.Balance = 0;
                    break;
            }
        }

        /// <summary>
        ///     右左旋操作
        /// </summary>
        private void RightLeftRotate(AvlTreeNode<T> node)
        {
            if (node.Right is not AvlTreeNode<T> right) return;
            var rightLeft = right.Left;

            var balance = rightLeft?.Balance;

            RightRotate(right);
            LeftRotate(node);

            switch (balance)
            {
                case 1:
                    node.Balance = 0;
                    right.Balance = -1;
                    break;
                case -1:
                    node.Balance = 1;
                    right.Balance = 0;
                    break;
                default:
                    node.Balance = 0;
                    right.Balance = 0;
                    break;
            }
        }

        /// <summary>
        ///     手动触发平衡
        /// </summary>
        private void Balance(AvlTreeNode<T>? node)
        {
            var currentNode = node;
            while (currentNode != null)
            {
                var left = currentNode.Left;
                var right = currentNode.Right;

                if ((node?.Balance ?? -1) >= 2 + (right?.Balance ?? -1))
                {
                    if (left != null && (left.Left?.Balance ?? -1) >= (left.Right?.Balance ?? -1))
                    {
                        RightRotate(currentNode);
                    }
                    else
                    {
                        LeftRotate(currentNode.Left);
                        RightRotate(currentNode);
                    }
                }
                else if ((right?.Balance ?? -1) >= 2 + (left?.Balance ?? -1))
                {
                    if (right != null && GetNodeBalance(right.Right) >= GetNodeBalance(right.Left))
                    {
                        LeftRotate(currentNode);
                    }
                    else
                    {
                        RightRotate(currentNode.Right);
                        LeftRotate(currentNode);
                    }
                }

                currentNode = currentNode.Parent;
            }
        }

        /// <summary>
        ///     获取结点平衡值
        /// </summary>
        /// <param name="node">结点</param>
        /// <returns></returns>
        private int GetNodeBalance(AvlTreeNode<T>? node)
        {
            return node?.Balance ?? -1;
        }
    }
}