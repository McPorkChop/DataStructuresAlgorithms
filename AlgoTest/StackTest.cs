using System;
using algo.model;
using NUnit.Framework;

namespace AlgoTest
{
    public class StackTest
    {
        private ArrayStack<int> _array;
        private LinkStack<int> _link;

        [SetUp]
        public void Setup()
        {
            _array = new ArrayStack<int>();
            _link = new LinkStack<int>();
        }

        [Test]
        public void Test1()
        {
            for (var i = 1; i <= 50; i++)
            {
                try
                {
                    _array.Push(i);
                }
                catch
                {
                    Console.WriteLine("栈满");
                }

                _link.Push(i);
            }

            Assert.IsTrue(_array.IsFull);
            Assert.AreEqual(_array.Top, 32);
            Assert.AreEqual(_link.Top, 50);
            var top = _array.Pop();
            Assert.AreEqual(top, 32);
            top = _link.Pop();
            Assert.AreEqual(top, 50);
            Assert.AreEqual(_array.Top, 31);
            Assert.AreEqual(_link.Top, 49);

            _array.Expand();
            Assert.AreEqual(_array.Top, 31);
            for (var i = 50; i < 60; i++)
            {
                _array.Push(i);
                _link.Push(i);
            }


            Assert.AreEqual(_array.Top, 59);
            Assert.AreEqual(_link.Top, 59);
        }
    }
}