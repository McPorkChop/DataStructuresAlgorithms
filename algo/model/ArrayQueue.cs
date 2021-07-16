using System;

namespace algo.model
{
    public class ArrayQueue<T> : AbstractArrayBase<T>, IQueue<T>
    {
        /// <summary>
        ///     头指针
        /// </summary>
        private  int head = -1;

        /// <summary>
        ///     尾指针
        /// </summary>
        private  int tail = -1;

        /// <summary>
        ///  是否满队
        /// </summary>
        public bool IsFull => tail - head + 1 >= Db.Length;

        public bool IsEmpty => head < 0 || tail < 0;
        public bool IsNotEmpty => head >= 0 && tail >= 0;

        
/// <summary>
/// 将队列移至首地址开始
/// </summary>
        private void MoveToZero()
        {
            if (head <= 0) return;
            for (var i = head; i <= tail; i++)
            {
                Db[i - head] = Db[i];
            }

            tail -= head;
            head = 0;
        }
        
        public T Enqueue(T el)
        {
            if (IsFull)
            {
                throw new Exception("当前队列已满，请先执行Expand进行扩容");
            }

            if (tail+1>=Db.Length)
            {
                MoveToZero();
            }

            Db[++tail] = el;
            if (head < 0) head = 0;
            return el;
        }

        public T? Dequeue()
        {
            if(IsEmpty) return new T?();
            var result= Db[head++];
            if (head > tail)
            {
                head = tail = -1;
            }

            return result;
        }
    }
}