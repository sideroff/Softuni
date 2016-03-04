using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_LinkedStack_Tests
{
    using _04_LinkedStack_Implementation;

    [TestClass]
    public class UnitTest1
    {
        private LinkedStack<int> newStack;
        [TestInitialize]
        public void Initialize()
        {
            this.newStack = new LinkedStack<int>();
        }

        [TestMethod]
        public void Push_OfCorrectElement_ShouldIncreaseCount()
        {
            this.newStack.Push(1);
            Assert.AreEqual(1,this.newStack.Count);
            this.newStack.Push(2);
            Assert.AreEqual(2, this.newStack.Count);
            this.newStack.Push(3);
            Assert.AreEqual(3, this.newStack.Count);
        }

        [TestMethod]
        public void Pop_OfSemiFullStack_ShouldDecreaseCount()
        {
            this.newStack.Push(1);
            this.newStack.Push(2);
            this.newStack.Push(3);

            this.newStack.Pop();
            Assert.AreEqual(2,this.newStack.Count);
            this.newStack.Pop();
            Assert.AreEqual(1, this.newStack.Count);
            this.newStack.Pop();
            Assert.AreEqual(0, this.newStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_OnEmptyStack_ShouldThrow()
        {
            this.newStack.Pop();
        }
    }
}
