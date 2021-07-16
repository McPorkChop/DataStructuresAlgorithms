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
            Db = new T[32];
        }

        /// <summary>
        ///     扩容
        /// </summary>
        
        public virtual void Expand()
        {
            var newLength = Convert.ToInt32(Db.Length * (1 + IncreaseFactor));
            var newArray = new T[newLength];
            for (var i = 0; i < Db.Length; i++) newArray[i] = Db[i];

            Db = newArray;
        }
    }
}