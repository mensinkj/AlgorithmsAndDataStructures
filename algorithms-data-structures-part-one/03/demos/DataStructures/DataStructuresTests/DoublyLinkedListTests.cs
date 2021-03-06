using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataStructuresTests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void InitalizeEmptyTest()
        {
            DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
            Assert.AreEqual(0, ints.Count);
        }

        [TestMethod]
        public void AddHeadTest()
        {
            DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                ints.AddHead(i);
                Assert.AreEqual(i, ints.Count);
            }

            int expected = 5;
            foreach (int x in ints)
            {
                Assert.AreEqual(expected--, x);
            }
        }

        [TestMethod]
        public void AddTailTest()
        {
            DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                ints.AddTail(i);
                Assert.AreEqual(i, ints.Count);
            }

            int expected = 1;
            foreach (int x in ints)
            {
                Assert.AreEqual(expected++, x);
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            DoublyLinkedList<int> delete1to10 = create(1, 10);
            Assert.AreEqual(10, delete1to10.Count);

            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(delete1to10.Remove(i));
                Assert.IsFalse(delete1to10.Remove(i));
            }

            Assert.AreEqual(0, delete1to10.Count);

            DoublyLinkedList<int> delete10to1 = create(1, 10);
            Assert.AreEqual(10, delete10to1.Count);

            for (int i = 10; i >= 1; i--)
            {
                Assert.IsTrue(delete10to1.Remove(i));
                Assert.IsFalse(delete10to1.Remove(i));
            }

            Assert.AreEqual(0, delete10to1.Count);
        }

        [TestMethod]
        public void RemoveMiddle()
        {
            DoublyLinkedList<int> del = create(1, 10);
            del.Remove(5);

            Assert.AreEqual(9, del.Count);
            Assert.IsTrue(del.Contains(4));
            Assert.IsFalse(del.Contains(5));
            Assert.IsTrue(del.Contains(6));

            AssertArraysSame(del.ToArray(), new[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 });
        }

        [TestMethod]
        public void ContainsTest()
        {
            DoublyLinkedList<int> ints = create(1, 10);
            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(ints.Contains(i));
            }

            Assert.IsFalse(ints.Contains(0));
            Assert.IsFalse(ints.Contains(11));
        }

        [TestMethod]
        public void ReverseIteratorTest()
        {
            DoublyLinkedList<int> ints = create(1, 10);
            int expected = 10;
            foreach(int actual in ints.GetReverseEnumerator())
            {
                Assert.AreEqual(expected--, actual);
            }
        }

        private DoublyLinkedList<int> create(int start, int end)
        {
            DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
            for (int i = start; i <= end; i++)
            {
                ints.AddTail(i);
            }

            return ints;
        }


        private void AssertArraysSame(int[] actual, int[] expected)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], string.Format("Incorrect value at index {0}", i));
            }
        }
    }
}
