namespace algo.model
{
    public class TreeNode<T>
    {
        /// <summary>
        /// 结点值
        /// </summary>
        public T value { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public TreeNode<T>?[] children { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">结点值</param>
        /// <param name="childCount">子节点数</param>
        public TreeNode(T value, int childCount)
        {
            this.value = value;
            this.children = new TreeNode<T>[childCount];
        }
    }
}
