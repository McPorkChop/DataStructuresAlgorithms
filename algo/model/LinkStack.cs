namespace algo.model
{
    /// <summary>
    ///     链表栈
    /// </summary>
    public class LinkStack<T> : IStack<T>where T : class

    {
        /// <summary>
        ///     头指针
        /// </summary>
        private readonly LinkNode<T> _top = new();

        public bool IsEmpty => _top.Next == null;
        public bool IsNotEmpty => _top.Next == null;
        public T? Top => _top.Data;

        public T Push(T el)
        {
            var node = new LinkNode<T>(el, _top.Next);
            _top.Next = node;
            return el;
        }

        public T? Pop()
        {
            if (_top.Next == null) return default;
            return _top.Next.Data ?? default;
        }
    }
}