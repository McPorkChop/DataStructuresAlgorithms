using System;
namespace algo.model
{
    public  class Tree<T>
    {
        /// <summary>
        /// 头指针
        /// </summary>
        LinkNode<TreeNode<T>> head { get; } = new LinkNode<TreeNode<T>>();


        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <returns></returns>
        T[] PreOrder()
        {
            return new T[0];
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <returns></returns>
        T[] PostOrder()
        {
            return new T[0];
        }
    }
}
