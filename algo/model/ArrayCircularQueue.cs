using System;

namespace algo.model
{
    /// <summary>
    ///     数组实现循环链表
    /// </summary>
    public class ArrayCircularQueue<T> : AbstractArrayBase<T>, IQueue<T>
    {
        /// <summary>
        ///     头指针
        /// </summary>
        private int _head = -1;

        /// <summary>
        ///     尾指针
        /// </summary>
        private int _tail;

        public ArrayCircularQueue(int capacity) : base(capacity)
        {
        }

        /// <summary>
        ///     是否满队
        /// </summary>
        public bool IsFull => Math.Abs(_tail - _head + 1) == Db.Length || _tail + 1 == _head;

        public bool IsEmpty => _head < 0;
        public bool IsNotEmpty => _head >= 0;
        public T? Next => IsEmpty ? default : Db[_head];

        public T Enqueue(T el)
        {
            if (IsFull) throw new Exception("当前队已满，请先执行Expand进行扩容");


            Db[_tail] = el;
            _tail = ++_tail % Db.Length;
            return el;
        }

        public T? Dequeue()
        {
            if (IsEmpty) return default;
            var result = Db[_head];
            _head = ++_head % Db.Length;
            return result;
        }


        /// <summary>
        ///     扩容
        /// </summary>
        public void Expand()
        {
            var newLength = Convert.ToInt32(Db.Length * (1 + IncreaseFactor));
            var newArray = new T[newLength];
            if (IsEmpty)
            {
                Db = newArray;
                return;
            }

            var start = _head;
            var end = _tail - _head;
            if (end < 0) end += Db.Length;
            var offset = end - start;
            var tmp = _head;
            var head = 0;
            do
            {
                newArray[++head] = Db[tmp];
            } while ((tmp = ++tmp % Db.Length) != _tail);

            _tail = offset;
            _head = 0;

            Db = newArray;
        }
    }
}