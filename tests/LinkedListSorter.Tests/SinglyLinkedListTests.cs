using Microsoft.VisualStudio.TestTools.UnitTesting;
// This using imports your linked list namespace from the app project
using LinkedListSorter.App.LinkedList;

namespace LinkedListSorter.Tests
{
    // The TestClass attribute marks this class as a container for test methods
    [TestClass]
    public class SinglyLinkedListTests
    {
        // This test verifies that when you create a new linked list, it is empty
        [TestMethod]
        public void NewList_ShouldBeEmpty()
        {
            var list = new SinglyLinkedList();      // Create a new list
            var values = list.ToArray<int>();            // Convert internal structure to array

            Assert.IsNotNull(values);               // Ensure the returned array is not null
            Assert.AreEqual(0, values.Length);      // Ensure the array is empty
        }

        // This test confirms that inserting a single value places exactly one item in the list
        [TestMethod]
        public void InsertAtEnd_SingleValue_ListContainsThatValue()
        {
            var list = new SinglyLinkedList();      
            list.InsertAtEnd(10);                   // Insert one value

            var values = list.ToArray<int>();            // Read list back out

            Assert.AreEqual(1, values.Length);      // Should only contain one element
            Assert.AreEqual(10, values[0]);         // That element should be 10
        }

        // This test ensures that insertion order is preserved when adding multiple nodes
        [TestMethod]
        public void InsertAtEnd_MultipleValues_PreservesInsertionOrder()
        {
            var list = new SinglyLinkedList();

            // Insert values in specific order
            list.InsertAtEnd(5);
            list.InsertAtEnd(2);
            list.InsertAtEnd(9);

            var values = list.ToArray<int>();            // Convert to array for easy comparison

            // Expected order must match insertion order
            CollectionAssert.AreEqual(new[] { 5, 2, 9 }, values);
        }

        // Verifies that ascending sort correctly orders an unsorted list
        [TestMethod]
        public void SortAscending_UnsortedList_SortsInAscendingOrder()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(5);
            list.InsertAtEnd(2);
            list.InsertAtEnd(9);
            list.InsertAtEnd(1);

            list.SortAscending();                   // Perform sort
            var values = list.ToArray<int>();

            // Validate sorted result
            CollectionAssert.AreEqual(new[] { 1, 2, 5, 9 }, values);
        }

        // If a list is already sorted in ascending order, sorting again should not change it
        [TestMethod]
        public void SortAscending_AlreadySortedList_RemainsInAscendingOrder()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(1);
            list.InsertAtEnd(2);
            list.InsertAtEnd(3);

            list.SortAscending();
            var values = list.ToArray();

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, values);
        }

        // Sorting a list with only one element should produce the same list
        [TestMethod]
        public void SortAscending_SingleElementList_RemainsUnchanged()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(42);

            list.SortAscending();
            var values = list.ToArray();

            CollectionAssert.AreEqual(new[] { 42 }, values);
        }

        // Sorting an empty list should not throw an exception and should remain empty
        [TestMethod]
        public void SortAscending_EmptyList_DoesNotThrowAndStaysEmpty()
        {
            var list = new SinglyLinkedList();

            list.SortAscending();
            var values = list.ToArray();

            Assert.AreEqual(0, values.Length);
        }

        // This test verifies descending sort on an unsorted list
        [TestMethod]
        public void SortDescending_UnsortedList_SortsInDescendingOrder()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(5);
            list.InsertAtEnd(2);
            list.InsertAtEnd(9);
            list.InsertAtEnd(1);

            list.SortDescending();
            var values = list.ToArray();

            CollectionAssert.AreEqual(new[] { 9, 5, 2, 1 }, values);
        }

        // Tests that a list already sorted in descending order remains unchanged
        [TestMethod]
        public void SortDescending_AlreadyDescendingList_RemainsInDescendingOrder()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(9);
            list.InsertAtEnd(5);
            list.InsertAtEnd(2);
            list.InsertAtEnd(1);

            list.SortDescending();
            var values = list.ToArray();

            CollectionAssert.AreEqual(new[] { 9, 5, 2, 1 }, values);
        }

        // Sorting a single element descending should produce the same list
        [TestMethod]
        public void SortDescending_SingleElementList_RemainsUnchanged()
        {
            var list = new SinglyLinkedList();
            list.InsertAtEnd(42);

            list.SortDescending();
            var values = list.ToArray();

            CollectionAssert.AreEqual(new[] { 42 }, values);
        }

        // Sorting an empty list descending should not throw
        [TestMethod]
        public void SortDescending_EmptyList_DoesNotThrowAndStaysEmpty()
        {
            var list = new SinglyLinkedList();

            list.SortDescending();
            var values = list.ToArray();

            Assert.AreEqual(0, values.Length);
        }
    }
}


