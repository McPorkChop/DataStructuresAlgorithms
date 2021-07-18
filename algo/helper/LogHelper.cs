using System;
using System.Diagnostics;

namespace algo.helper
{
    /// <summary>
    ///     日志帮助类
    /// </summary>
    public class LogHelper
    {
        public static readonly LogHelper Instance = new();

        public LogHelper Do<T>(Action func, Func<T> selector)
        {
            try
            {
                var watch = new Stopwatch();
                var beforeValue = selector();
                Console.WriteLine("before:\t" + beforeValue ?? "---");
                watch.Start();
                func();
                watch.Stop();
                var afterValue = selector();
                Console.WriteLine("after:\t" + afterValue ?? "---");
                Console.WriteLine("耗时：\t" + watch.ElapsedMilliseconds);
                Console.WriteLine("\n");
                return this;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\n");
                return this;
            }
        }
    }
}