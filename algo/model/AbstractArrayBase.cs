using System;

namespace algo.model
{
    public abstract class AbstractArrayBase<T>
    {
        /// <summary>
        ///     增长因子
        /// </summary>
        protected const decimal IncreaseFactor = 0.75m;

        /// <summary>
        ///     数组
        /// </summary>
        protected T[] Db;

        /// <summary>
        /// </summary>
        /// <param name="capacity">初始大小</param>
        protected AbstractArrayBase(int capacity = 32)
        {
            Db = new T[capacity];
        }

        /// <summary>
        ///     数组大小
        /// </summary>
        public virtual int Size => Db.Length;

        /// <summary>
        ///     扩容
        /// </summary>
        /// <param name="start">开始位置</param>
        /// <param name="length">数据长度</param>
        public virtual void Expand(int start = 0, int? length = null)
        {
            var newLength = Convert.ToInt32(Db.Length * (1 + IncreaseFactor));
            var end = length ?? Db.Length - start - 1;
            var newArray = new T[newLength];
            for (var i = 0; i <= end; i++) newArray[i] = Db[start + i];

            Db = newArray;
        }
    }
}