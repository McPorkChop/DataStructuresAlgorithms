namespace algo.model
{
    public class LinkCircularQueue<T>:IQueue<T>
    {
        /// <summary>
        ///  尾指针
        /// </summary>
        private LinkNode<T> _tail=new LinkNode<T>();

        private LinkNode<T> _head = new LinkNode<T>();

      public  LinkCircularQueue()
      {
          _head.Next = _tail;
          _tail.Next = _head;
      }

      public bool IsEmpty => _tail.Next!.Next==_tail;
      public bool IsNotEmpty => _tail.Next!.Next != _tail;
      public T? Next => IsEmpty?default: _head.Next!.Data;
        public T Enqueue(T el)
        {
            throw new System.NotImplementedException();
        }

        public T? Dequeue()
        {
            throw new System.NotImplementedException();
        }
    }
}