
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_ArrayList_Tests
{
    using _03_ArrayStack_Implementation;

    [TestClass]
    public class UnitTest1
    {
        private ArrayStack<int> newStack;
        [TestInitialize]
        public void Initialize()
        {
            this.newStack = new ArrayStack<int>();
        }
        [TestMethod]
        public void Push_RandomElement_ShouldIncreaseCount()
        {
            var randomElement = 55;

            this.newStack.Push(randomElement);
            Assert.AreEqual(1, this.newStack.Count);

            this.newStack.Push(randomElement);
            Assert.AreEqual(2, this.newStack.Count);

            this.newStack.Push(randomElement);
            Assert.AreEqual(3, this.newStack.Count);
        }

        public void Pop_OnRandomNumberOfElements_ShouldDecreaseCount()
        {
            var randomElement = 55;

            this.newStack.Push(randomElement);
            this.newStack.Push(randomElement);
            this.newStack.Push(randomElement);

            this.newStack.Pop();
            this.newStack.Pop();

            Assert.AreEqual(1, this.newStack.Count);
        }

        public void Pop_OnRandomNumberOfElements_ShouldReturnLastAddedElement()
        {
            var randomElement = 55;

            this.newStack.Push(randomElement);
            this.newStack.Push(randomElement+1);
            this.newStack.Push(randomElement+2);

            var shouldBe57 =  this.newStack.Pop();
            var shouldBe56 =this.newStack.Pop();

            Assert.AreEqual(57, shouldBe57);
            Assert.AreEqual(56, shouldBe56);
        }
    }
}
