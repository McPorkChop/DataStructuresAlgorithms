namespace algo.model
{
    /// <summary>
    ///     单链表节点结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkNode<T>where T : class
    {
        public LinkNode()
        {
            Data = default;
            Next = null;
        }

        public LinkNode(T data, LinkNode<T>? next=null)
        {
            this.Data = data;
            this.Next = next;
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