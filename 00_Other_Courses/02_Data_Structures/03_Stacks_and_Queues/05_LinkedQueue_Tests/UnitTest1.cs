using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_LinkedQueue_Tests
{
    using _05_LinkedQueue_Implementation;

    [TestClass]
    public class UnitTest1
    {
        private LinkedQueue<int> queue;

        [TestInitialize]
        public void Initialize()
        {
            this.queue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void Enqueue_WithNormalElements_ShouldIncreaseCount()
        {
            this.queue.Enqueue(1);
            Assert.AreEqual(1,this.queue.Count);
            this.queue.Enqueue(2);
            Assert.AreEqual(2, this.queue.Count);
            this.queue.Enqueue(3);
            Assert.AreEqual(3, this.queue.Count);
        }

        [TestMethod]
        public void Dequeue_WithSemiFullQueue_ShouldDecreaseCount()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);
            this.queue.Enqueue(3);

            this.queue.Dequeue();
            Assert.AreEqual(2, this.queue.Count);
            this.queue.Dequeue();
            Assert.AreEqual(1, this.queue.Count);
            this.queue.Dequeue();
            Assert.AreEqual(0, this.queue.Count);
        }

        [TestMethod]
        public void Dequeue_WithSemiFullQueue_ShouldReturnCorrectElement()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);
            this.queue.Enqueue(3);
            
            Assert.AreEqual(1, this.queue.Dequeue());
            Assert.AreEqual(2, this.queue.Dequeue());
            Assert.AreEqual(3, this.queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_OnEmptyQueue_ShouldThrow()
        {
            this.queue.Dequeue();
        }
    }
}

