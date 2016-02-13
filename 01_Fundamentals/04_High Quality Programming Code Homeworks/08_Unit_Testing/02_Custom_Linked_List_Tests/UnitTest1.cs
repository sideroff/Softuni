using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Custom_Linked_List_Tests
{
    using CustomLinkedList;
    //contains test methods which i believe are whats expected of the operations provided,
    //not necessarily ones that will pass
    [TestClass]
    public class CustomDinamicLinkedListTests
    {
        private DynamicList<int> testMember;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }
        
        [TestInitialize]
        public void TestInitialize()
        {
            this.testMember = new DynamicList<int>();
        }
        
        [TestMethod]
        public void Add_AddCorrectElement_ShouldIncreaseCount()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            Assert.AreEqual(2, testMember.Count,
                "Count should return the correct number of elements in the dynamic list");
        }
        
        [TestMethod]
        public void Count_OnMemberWith0Elements_ShouldBe0()
        {
            Assert.AreEqual(0, this.testMember.Count,
                "Count of list with 0 elements should return 0");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
            "Remove on an empty list should throw exception - > list is empty / nothing to remove")]
        public void Remove_OnEmptyList_ShouldThrow()
        {
            this.testMember.Remove(5);
        }
        
        [TestMethod]
        public void Remove_AfterAddingCorrectElements_ShouldDecreaseCount()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            this.testMember.Remove(6);

            Assert.AreEqual(1, testMember.Count,
                "Remove should decrease Count");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Should not allow element with negative index to be accessed/removed")]
        public void RemoveAt_NegativeIndex_ShouldThrow()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            this.testMember.IndexOf(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Should not allow element with index greater than count to be accessed/removed")]
        public void RemoveAt_IndexGreaterThanCount_ShouldThrow()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            this.testMember.RemoveAt(2);
        }

        [TestMethod]
        public void Contains_AfterAddincCorrectElement_ShouldReturnTrue()
        {
            this.testMember.Add(5);

            Assert.IsTrue(this.testMember.Contains(5),
                "Contains(element) should return true after adding the element");
        }

        [TestMethod]
        public void Contains_AfterRemovingCorrectElement_ShouldReturnFalse()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            this.testMember.Remove(6);

            Assert.IsTrue(testMember.Contains(6),
                "Contains should return false when the element is not present");
        }

        [TestMethod]
        public void IndexOf_AfterAddingCorrectElement_ShouldReturnCorrectIndex()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            Assert.AreEqual(2, testMember.IndexOf(6),
                "IndexOf should return correct index of the specified element");
        }
        
        [TestMethod]
        public void IndexOf_SecondAddedElement_ShouldReturn1()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            Assert.AreEqual(1,testMember.IndexOf(6),
                "IndexOf should return the correct index of the element");
        }

        [TestMethod]
        public void IndexOf_SecondAddedElementAfterRemovalOfFirst_ShouldReturn0()
        {
            this.testMember.Add(5);
            this.testMember.Add(6);

            this.testMember.Remove(5);

            Assert.AreEqual(0, testMember.IndexOf(6),
                "Remove should update index of elements");
        }
    }
}
