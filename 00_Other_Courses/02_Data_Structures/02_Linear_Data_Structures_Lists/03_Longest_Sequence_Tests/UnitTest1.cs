using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Longest_Sequence_Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using _03_Longest_Subsequence;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LongestSequence_OnDifferentNumbersList_IsFirstElement()
        {
            string numbers = "1 2 3 4";
            List<int> list = numbers.Split().Select(int.Parse).ToList();

            var sequenceFinder = new Sequence_Finder();

            string result = sequenceFinder.Get_Longest_Sequence(list);

            Assert.AreEqual("1",result);
        }
        [TestMethod]
        public void LongestSequence_OnListWithSomeEqualElements_IsTheRightElements()
        {
            string numbers = "1 2 3 3 4 5 6";
            List<int> list = numbers.Split().Select(int.Parse).ToList();

            var sequenceFinder = new Sequence_Finder();

            string result = sequenceFinder.Get_Longest_Sequence(list);

            Assert.AreEqual("3 3", result);
        }
        [TestMethod]
        public void LongestSequence_OnListWith3EqualElements_IsThe3Elements()
        {
            string numbers = "3 3 3";
            List<int> list = numbers.Split().Select(int.Parse).ToList();

            var sequenceFinder = new Sequence_Finder();

            string result = sequenceFinder.Get_Longest_Sequence(list);

            Assert.AreEqual("3 3 3", result);
        }

        [TestMethod]
        public void LongestSequence_OnListWith2Subsequences_IsTheBiggerSubsequence()
        {
            string numbers = "1 2 3 3 4 5 5 5";
            List<int> list = numbers.Split().Select(int.Parse).ToList();

            var sequenceFinder = new Sequence_Finder();

            string result = sequenceFinder.Get_Longest_Sequence(list);

            Assert.AreEqual("5 5 5", result);
        }

        [TestMethod]
        public void LongestSequence_OnListWith2EqualInLenghtSubsequences_IsTheFirstSubsequence()
        {
            string numbers = "1 2 3 3 3 4 4 4";
            List<int> list = numbers.Split().Select(int.Parse).ToList();

            var sequenceFinder = new Sequence_Finder();

            string result = sequenceFinder.Get_Longest_Sequence(list);

            Assert.AreEqual("3 3 3", result);
        }
    }
}
