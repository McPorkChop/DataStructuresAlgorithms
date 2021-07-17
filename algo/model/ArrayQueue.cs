using System;

namespace algo.model
{
    /// <summary>
    ///     普通数组队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayQueue<T> : AbstractArrayBase<T>, IQueue<T>where T : class
    {
        /// <summary>
        ///     头指针
        /// </summary>
        private int _head = -1;

        /// <summary>
        ///     尾指针
        /// </summary>
        private int _tail = -1;

        /// <summary>
        ///     是否满队
        /// </summary>
        public bool IsFull => _tail - _head + 1 >= Db.Length;

        public bool IsEmpty => _head < 0 || _tail < 0;
        public bool IsNotEmpty => _head >= 0 && _tail >= 0;

        public T Enqueue(T el)
        {
            if (IsFull) throw new Exception("当前队列已满，请先执行Expand进行扩容");

            if (_tail + 1 >= Db.Length) MoveToZero();

            Db[++_tail] = el;
            if (_head < 0) _head = 0;
            return el;
        }

        public T? Dequeue()
        {
            if (IsEmpty) return default;
            var result = Db[_head++];
            if (_head > _tail) _head = _tail = -1;

            return result;
        }


        /// <summary>
        ///     扩容
        /// </summary>
        public void Expand()
        {
            if (IsEmpty)
            {
                base.Expand();
                return;
            }

            MoveToZero();
            base.Expand(0, _tail - _head);
        }

        /// <summary>
        ///     将队列移至首地址开始
        /// </summary>
        private void MoveToZero()
        {
            if (_head <= 0) return;
            for (var i = _head; i <= _tail; i++) Db[i - _head] = Db[i];

            _tail -= _head;
            _head = 0;
        }
    }
}