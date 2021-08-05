using System;
namespace algo.model
{
    /// <summary>
    /// 二叉树接口
    /// </summary>
    public  class BinaryTree<T>: Tree<T>
    {

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <returns></returns>
      public  T[] InOrder()
        {

            return new T[0];
        }

        /// <summary>
        /// 插入新结点
        /// </summary>
        /// <param name="value">结点值</param>
        public void insert(T value)
        {

        }

        /// <summary>
        /// 删除结点
        /// </summary>
        /// <param name="value">结点值</param>
        public void remove(T value)
        {

        }

        /// <summary>
        /// 查找结点
        /// </summary>
        /// <param name="value">结点值</param>
        /// <returns>结点</returns>
        public BinaryTreeNode<T>? find(T value)
        {
            return null;
        }
    }
}
