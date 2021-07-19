using System;
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
        }

        /// <summary>
        ///  普通数组实现
        /// </summary>
        [Test]
        public void NormalArray()
        {
            var array = new ArrayQueue<int>();
            Assert.Catch(() =>
            {
                for (var i = 1; i <= 50; i++) array.Enqueue(i);
            });

            Assert.IsTrue(array.IsFull);
            Assert.AreEqual(array.Next, 1);
            Assert.AreEqual(array.Size, 32);
            var first = array.Dequeue();
            Assert.AreEqual(first, 1);
            Assert.AreEqual(array.Next, 2);

            array.Expand();
            Assert.AreEqual(array.Size, Convert.ToInt32(32 * 1.75));
            Assert.Catch(() =>
            {
                var seek = new Random();
                for (var i = 51; i < 10000; i++)
                    if (seek.Next(100) % 3 == 0) array.Dequeue();
                    else  array.Enqueue(i);
            });


            Assert.IsTrue(array.IsFull);
            do
            {
                array.Dequeue();
            } while (array.IsNotEmpty);

            Assert.IsTrue(array.IsEmpty);
        }

        /// <summary>
        ///     普通链表实现
        /// </summary>
        [Test]
        public void NormalLink()
        {
            var queue = new LinkQueue<int>();
            for (var i = 1; i <= 50; i++) queue.Enqueue(i);
            Assert.AreEqual(queue.Next, 1);
            var first = queue.Dequeue();
            Assert.AreEqual(queue.Next, 2);
            Assert.AreEqual(first, 1);

            for (var i = 0; i < 30; i++) queue.Dequeue();
            Assert.AreEqual(queue.Next, 32);

            for (var i = 50; i < 70; i++) queue.Enqueue(i);


            do
            {
                queue.Dequeue();
            } while (queue.IsNotEmpty);

            Assert.AreEqual(queue.Dequeue(), 0);

            Assert.IsTrue(queue.IsEmpty);
        }
        
        /// <summary>
        ///     循环队列实现
        /// </summary>
        [Test]
        public void CircleArray()
        {
            var array = new ArrayCircularQueue<int>();
            Assert.Catch(() =>
            {
                for (var i = 1; i <= 50; i++) array.Enqueue(i);
            });

            Assert.IsTrue(array.IsFull);
            Assert.AreEqual(array.Next, 1);
            Assert.AreEqual(array.Size, 31);
            var first = array.Dequeue();
            Assert.AreEqual(first, 1);
            Assert.AreEqual(array.Next, 2);

            array.Expand();
            Assert.AreEqual(array.Size, Convert.ToInt32(32 * 1.75)-1);
            Assert.Catch(() =>
            {
                var seek = new Random();
                for (var i = 51; i < 10000; i++)
                    if (seek.Next(100) % 3 == 0) array.Dequeue();
                    else  array.Enqueue(i);
            });


            Assert.IsTrue(array.IsFull);
            do
            {
                array.Dequeue();
            } while (array.IsNotEmpty);

            Assert.IsTrue(array.IsEmpty);
        }
    }
}