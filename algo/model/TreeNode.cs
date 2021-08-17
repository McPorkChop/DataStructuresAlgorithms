using System.Collections.Generic;

namespace algo.model
{
    public class TreeNode<T>
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="data">结点值</param>
        /// <param name="childCount">子节点数</param>
        public TreeNode(T data, int childCount)
        {
            Data = data;
            Children = new List<TreeNode<T>>(childCount);
        }

        protected TreeNode()
        {
        }

        /// <summary>
        ///     结点值
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        ///     父结点
        /// </summary>
        public TreeNode<T>? Parent { get; set; }

        /// <summary>
        ///     子节点
        /// </summary>
        public List<TreeNode<T>> Children { get; }
    }
}