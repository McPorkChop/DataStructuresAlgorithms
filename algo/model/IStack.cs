namespace algo.model
{
    public interface IStack<T>
    {
        /// <summary>
        ///     栈是否为空
        /// </summary>
        public bool IsEmpty { get; }

        /// <summary>
        ///     栈是否为非空
        /// </summary>
        public bool IsNotEmpty { get; }

        /// <summary>
        ///     栈顶元素
        /// </summary>
        public T? Top { get; }

        /// <summary>
        ///     推入栈
        /// </summary>
        /// <param name="el">数据</param>
        /// <returns>栈顶元素</returns>
        public T Push(T el);

        /// <summary>
        ///     获取顶部元素
        /// </summary>
        /// <returns>栈顶元素，空栈时返回空</returns>
        public T? Pop();
    }
}