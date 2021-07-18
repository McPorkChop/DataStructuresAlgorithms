namespace algo.model
{
    public interface IQueue<T>
    {
        /// <summary>
        ///     队列是否为空
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        ///     队列是否非空
        /// </summary>
        bool IsNotEmpty { get; }

        /// <summary>
        ///     下一个出队元素
        /// </summary>
        T? Next { get; }

        /// <summary>
        ///     入队
        /// </summary>
        /// <param name="el">入队元素</param>
        /// <returns>入队元素</returns>
        T Enqueue(T el);

        /// <summary>
        ///     出队
        /// </summary>
        /// <returns>出队元素</returns>
        T? Dequeue();
    }
}