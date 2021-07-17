namespace algo.model
{
    public class LinkQueue<T>:IQueue<T>where T : class
    {
        /// <summary>
        /// 头指针，完全不存放任何数据
        /// </summary>
        private LinkNode<T> _head=new LinkNode<T>();

        /// <summary>
        /// 尾指针
        /// </summary>
        private LinkNode<T>? _tail=null;


        public bool IsEmpty => _head.Next == _tail;
        public bool IsNotEmpty => _head.Next != _tail;
        public T Enqueue(T el)
        {
            var node = new LinkNode<T>(el);
            if (IsEmpty)
            {
                _head.Next = node;
            }
            else
            {
                _tail!.Next = node;
            }
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
    }
}