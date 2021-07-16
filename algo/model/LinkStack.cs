namespace algo.model
{
    /// <summary>
    ///     链表栈
    /// </summary>
    public class LinkStack<T> : IStack<T>

    {
        /// <summary>
        ///     头指针
        /// </summary>
        private readonly LinkNode<T> _top = new();

        public bool IsEmpty => _top.next == null;
        public bool IsNotEmpty => _top.next == null;
        public T? Top => _top.data;

        public T Push(T el)
        {
            var node = new LinkNode<T>(el, _top.next);
            _top.next = node;
            return el;
        }

        public T? Pop()
        {
            if (_top.next == null) return new T?();
            return _top.next.data ?? new T?();
        }
    }
}