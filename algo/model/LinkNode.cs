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
            data = new T?();
            next = null;
        }

        public LinkNode(T data, LinkNode<T>? next)
        {
            this.data = data;
            this.next = next;
        }

        /// <summary>
        ///     节点数据
        /// </summary>
        public T? data { get; set; }

        /// <summary>
        ///     Next指针
        /// </summary>
        public LinkNode<T>? next { get; set; }
    }
}