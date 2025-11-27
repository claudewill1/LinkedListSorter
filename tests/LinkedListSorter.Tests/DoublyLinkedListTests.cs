using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListSorter.App.LinkedList;

namespace LinkedListSorter.Tests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void NewDoublyList_ShouldBeEmpty()
        {
            var list = new DoublyLinkedList();

            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
            Assert.AreEqual(0, list.count);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            Assert.AreEqual(0, forward.Length);
            Assert.AreEqual(0, backward.Length);
        }

        [TestMethod]
        public void AddFirst_SingleNode_HeadAndTailSame()
        {
            var list = new DoublyLinkedList();

            list.AddFirst(10);

            Assert.IsNotNull(list.head);
            Assert.IsNotNull(list.tail);
            Assert.AreSame(list.head, list.tail);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 10 }, forward);
            CollectionAssert.AreEqual(new[] { 10 }, backward);
        }

        [TestMethod]
        public void AddLast_SingleNode_HeadAndTailSame()
        {
            var list = new DoublyLinkedList();

            list.AddLast(20);

            Assert.IsNotNull(list.head);
            Assert.IsNotNull(list.tail);
            Assert.AreSame(list.head, list.tail);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 20 }, forward);
            CollectionAssert.AreEqual(new[] { 20 }, backward);
        }

        [TestMethod]
        public void AddFirstAndAddLast_PreservesForwardOrder()
        {
            var list = new DoublyLinkedList();

            list.AddFirst(2);   // list: 2
            list.AddFirst(1);   // list: 1, 2
            list.AddLast(3);    // list: 1, 2, 3

            var forward = list.ToArrayForward();

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, forward);
        }

        [TestMethod]
        public void AddFirstAndAddLast_PreservesBackwardOrder()
        {
            var list = new DoublyLinkedList();

            list.AddFirst(2);   // list: 2
            list.AddFirst(1);   // list: 1, 2
            list.AddLast(3);    // list: 1, 2, 3

            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 3, 2, 1 }, backward);
        }

        [TestMethod]
        public void RemoveFirst_RemovesHeadAndUpdatesLinks()
        {
            var list = new DoublyLinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            var removed = list.RemoveFirst();

            Assert.IsTrue(removed);
            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 2, 3 }, forward);
            CollectionAssert.AreEqual(new[] { 3, 2 }, backward);
        }

        [TestMethod]
        public void RemoveLast_RemovesTailAndUpdatesLinks()
        {
            var list = new DoublyLinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            var removed = list.RemoveLast();

            Assert.IsTrue(removed);
            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 1, 2 }, forward);
            CollectionAssert.AreEqual(new[] { 2, 1 }, backward);
        }

        [TestMethod]
        public void Remove_RemovesMatchingValueInMiddle()
        {
            var list = new DoublyLinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            var removed = list.Remove(2);

            Assert.IsTrue(removed);
            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 1, 3 }, forward);
            CollectionAssert.AreEqual(new[] { 3, 1 }, backward);
        }

        [TestMethod]
        public void SortAscending_SortsValuesForward()
        {
            var list = new DoublyLinkedList();
            list.AddLast(5);
            list.AddLast(1);
            list.AddLast(3);

            list.SortAscending();

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, forward);
            CollectionAssert.AreEqual(new[] { 5, 3, 1 }, backward);
        }

        [TestMethod]
        public void SortDescending_SortsValuesBackward()
        {
            var list = new DoublyLinkedList();
            list.AddLast(5);
            list.AddLast(1);
            list.AddLast(3);

            list.SortDescending();

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 5, 3, 1 }, forward);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, backward);
        }

        [TestMethod]
        public void Clear_EmptiesList()
        {
            var list = new DoublyLinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.Clear();

            Assert.AreEqual(0, list.count);
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            Assert.AreEqual(0, forward.Length);
            Assert.AreEqual(0, backward.Length);
        }
    }
}
