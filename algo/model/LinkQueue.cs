namespace algo.model
{
    public class LinkQueue<T> : IQueue<T>
    {
        /// <summary>
        ///     头指针，完全不存放任何数据
        /// </summary>
        private readonly LinkNode<T> _head = new();

        /// <summary>
        ///     尾指针
        /// </summary>
        private LinkNode<T>? _tail;


        public bool IsEmpty => _head.Next == null || _tail == null;
        public bool IsNotEmpty => _head.Next != null && _tail != null;

        public T Enqueue(T el)
        {
            var node = new LinkNode<T>(el);
            if (IsEmpty)
            {
                _head.Next = _tail = node;
                return el;
            }


            _tail!.Next = node;
            _tail = node;

            return el;
        }

        public T? Dequeue()
        {
            if (IsEmpty) return default;
            var result = _head.Next!.Data;
            _head.Next = _head.Next?.Next;
            if (_head.Next == null) _tail = null;
            return result;
        }

        public T? Next
        {
            get
            {
                if (_head.Next == null) return default;
                return _head.Next.Data;
            }
        }
    }
}