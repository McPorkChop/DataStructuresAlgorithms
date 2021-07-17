using System;

namespace algo.model
{
    /// <summary>
    ///     数组栈
    /// </summary>
    public class ArrayStack<T> : AbstractArrayBase<T>, IStack<T>
    {
        /// <summary>
        ///     栈顶
        /// </summary>
        private int _top = -1;

        public ArrayStack(int capacity = 32) : base(capacity)
        {
        }

        /// <summary>
        ///     是否满栈
        /// </summary>
        public bool IsFull => _top+1 >= Db.Length;

        /// <summary>
        ///     栈是否为空
        /// </summary>
        public bool IsEmpty => _top < 0;

        /// <summary>
        ///     栈是否为非空
        /// </summary>
        public bool IsNotEmpty => _top >= 0;

        /// <summary>
        ///     栈顶元素
        /// </summary>
        public T? Top => IsNotEmpty ? Db[_top] : default;

        public T Push(T el)
        {
            if (IsFull) throw new Exception("当前栈已满，请先执行Expand进行扩容");
            Db[++_top] = el;
            return el;
        }

        /// <summary>
        ///     获取顶部元素
        /// </summary>
        /// <returns></returns>
        public T? Pop()
        {
            return IsEmpty ? default : Db[_top--];
        }
    }
}