namespace algo.model
{
    public class LinkCircularQueue<T> : IQueue<T>
    {
        /// <summary>
        ///     头指针
        /// </summary>
        private readonly LinkNode<T> _head = new();

        /// <summary>
        ///     尾指针
        /// </summary>
        private LinkNode<T>? _tail;


        public bool IsEmpty => _tail == null;
        public bool IsNotEmpty => _tail != null;
        public T? Next => IsEmpty ? default : _head.Next!.Data;

        public T Enqueue(T el)
        {
            var node = new LinkNode<T>(el);
            if (IsEmpty)
            {
                node.Next = node;
                _tail = node;
                _head.Next = node;
                return el;
            }

            node.Next = _tail!.Next;
            _tail.Next = node;
            _tail = node;
            return el;
        }

        public T? Dequeue()
        {
            if (IsEmpty) return default;
            var result = _tail!.Next!.Data!;
            if (_tail == _tail!.Next)
            {
                _tail = null;
                _head.Next = null;
                return result;
            }

            _tail.Next = _head.Next!.Next;
            _head.Next = _tail.Next;
            return result;
        }
    }
}