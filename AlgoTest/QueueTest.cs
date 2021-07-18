using algo.model;
using NUnit.Framework;

namespace AlgoTest
{
    [TestFixture]
    public class QueueTest
    {
        [SetUp]
        public void Setup()
        {
            _link = new LinkQueue<int>();
            _array = new ArrayQueue<int>();
        }

        private LinkQueue<int> _link;
        private ArrayQueue<int> _array;

        [Test]
        public void Test1()
        {
            for (var i = 1; i <= 50; i++)
            {
                _link.Enqueue(i);
                _array.Enqueue(i);
            }

            Assert.IsTrue(_array.IsFull);
            Assert.AreEqual(_link.Next, 1);
            Assert.AreEqual(_link.Next, _array.Next);
            var _first = _link.Dequeue();
            var _second = _array.Dequeue();
            Assert.AreEqual(_first, 1);
            Assert.AreEqual(_first, _second);
            Assert.AreEqual(_link.Next, 2);
            Assert.AreEqual(_link.Next, _array.Next);

            _array.Expand();
            for (var i = 51; i < 60; i++)
            {
                _link.Enqueue(i);
                _array.Enqueue(i);
            }


            Assert.AreEqual(_link.Next, 2);
            Assert.AreEqual(_link.Next, _array.Next);
            do
            {
                _link.Dequeue();
                _array.Dequeue();
            } while (_link.IsNotEmpty);

            Assert.IsTrue(_link.IsEmpty);
        }
    }
}