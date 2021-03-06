using System;
using algo.helper;
using algo.model;

namespace algo
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ArrayStack");
            var arrayStack = new ArrayStack<int>(5);
            Console.WriteLine("IsFull:\t\t" + arrayStack.IsFull);
            Console.WriteLine("IsEmpty:\t" + arrayStack.IsEmpty);
            Console.WriteLine("IsNotEmpty:\t" + arrayStack.IsNotEmpty);
            LogHelper.Instance
                .Do(() => arrayStack.Push(1), () => arrayStack.Top)
                .Do(() => arrayStack.Push(2), () => arrayStack.Top)
                .Do(() => arrayStack.Push(3), () => arrayStack.Top)
                .Do(() => arrayStack.Push(4), () => arrayStack.Top)
                .Do(() => arrayStack.Push(5), () => arrayStack.Top)
                .Do(() => arrayStack.Push(6), () => arrayStack.Top)
                .Do(() => arrayStack.Pop(), () => arrayStack.Top);
        }
    }
}