using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListSorter.App.LinkedList;
using LinkedListSorter.App.Services;

namespace LinkedListSorter.Tests
{
    [TestClass]
    public class SortingServiceTests
    {
        private SortingService _sortingService;

        [TestInitialize]
        public void Setup()
        {
            _sortingService = new SortingService();
        }

        // ---------------------------
        // SinglyLinkedList tests
        // ---------------------------

        [TestMethod]
        public void SortSinglyAscending_UnsortedValues_SortsInAscendingOrder()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(5);
            list.InsertAtEnd(1);
            list.InsertAtEnd(3);

            _sortingService.SortSinglyAscending(list);

            var result = list.ToArray();

            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, result);
        }

        [TestMethod]
        public void SortSinglyDescending_UnsortedValues_SortsInDescendingOrder()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(5);
            list.InsertAtEnd(1);
            list.InsertAtEnd(3);

            _sortingService.SortSinglyDescending(list);

            var result = list.ToArray();

            CollectionAssert.AreEqual(new[] { 5, 3, 1 }, result);
        }

        [TestMethod]
        public void SortSinglyAscending_EmptyList_DoesNotThrowAndRemainsEmpty()
        {
            var list = new SinglyLinkedList();

            _sortingService.SortSinglyAscending(list);

            var result = list.ToArray();

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void SortSinglyAscending_SingleElementList_RemainsUnchanged()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(42);

            _sortingService.SortSinglyAscending(list);

            var result = list.ToArray();

            CollectionAssert.AreEqual(new[] { 42 }, result);
        }

        // ---------------------------
        // DoublyLinkedList tests
        // ---------------------------

        [TestMethod]
        public void SortDoublyAscending_UnsortedValues_SortsInAscendingOrder_ForwardAndBackward()
        {
            var list = new DoublyLinkedList();
            list.AddLast(5);
            list.AddLast(1);
            list.AddLast(3);

            _sortingService.SortDoublyAscending(list);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, forward);
            CollectionAssert.AreEqual(new[] { 5, 3, 1 }, backward);
        }

        [TestMethod]
        public void SortDoublyDescending_UnsortedValues_SortsInDescendingOrder_ForwardAndBackward()
        {
            var list = new DoublyLinkedList();
            list.AddLast(5);
            list.AddLast(1);
            list.AddLast(3);

            _sortingService.SortDoublyDescending(list);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 5, 3, 1 }, forward);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, backward);
        }

        [TestMethod]
        public void SortDoublyAscending_EmptyList_DoesNotThrowAndRemainsEmpty()
        {
            var list = new DoublyLinkedList();

            _sortingService.SortDoublyAscending(list);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            Assert.AreEqual(0, forward.Length);
            Assert.AreEqual(0, backward.Length);
        }

        [TestMethod]
        public void SortDoublyAscending_SingleElementList_RemainsUnchanged()
        {
            var list = new DoublyLinkedList();
            list.AddLast(42);

            _sortingService.SortDoublyAscending(list);

            var forward = list.ToArrayForward();
            var backward = list.ToArrayBackward();

            CollectionAssert.AreEqual(new[] { 42 }, forward);
            CollectionAssert.AreEqual(new[] { 42 }, backward);
        }
    }
}
