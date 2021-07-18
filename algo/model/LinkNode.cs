namespace algo.model
{
    /// <summary>
    ///     单链表节点结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkNode<T>
    {
        public LinkNode()
        {
            Data = default;
            Next = null;
        }

        public LinkNode(T data, LinkNode<T>? next = null)
        {
            Data = data;
            Next = next;
        }

        /// <summary>
        ///     节点数据
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        ///     Next指针
        /// </summary>
        public LinkNode<T>? Next { get; set; }
    }
}