using System;
using LinkedListSorter.App.LinkedList;

namespace LinkedListSorter.App.Services
{
    /// <summary>
    /// Provides sorting operations for singly and doubly linked lists.
    /// This service delegates sorting to the existing methods implemented
    /// inside the list classes and does not contain sorting logic itself.
    /// </summary>
    public class SortingService
    {
        
        // ---------------------------------------------------------
        // Singly Linked List Sorting
        // ---------------------------------------------------------

        /// <summary>
        /// Sorts a SinglyLinkedList in ascending order.
        /// This method calls the list's internal SortAscending implementation.
        /// </summary>
        /// <param name="list">The singly linked list to be sorted.</param>
        public void SortSinglyAscending(SinglyLinkedList list)
        {
            list.SortAscending();
        }

        /// <summary>
        /// Sorts a SinglyLinkedList in descending order.
        /// This method calls the list's internal SortDescending implementation.
        /// </summary>
        /// <param name="list">The singly linked list to be sorted.</param>
        public void SortSinglyDescending(SinglyLinkedList list)
        {
            list.SortDescending();
        }


        // ---------------------------------------------------------
        // Doubly Linked List Sorting
        // ---------------------------------------------------------

        /// <summary>
        /// Sorts a DoublyLinkedList in ascending order.
        /// Delegates to the list's built-in recursive merge sort.
        /// </summary>
        /// <param name="list">The doubly linked list to be sorted.</param>
        public void SortDoublyAscending(DoublyLinkedList list)
        {
            list.SortAscending();
        }

        /// <summary>
        /// Sorts a DoublyLinkedList in descending order.
        /// Delegates to the list's built-in descending sort logic.
        /// </summary>
        /// <param name="list">The doubly linked list to be sorted.</param>
        public void SortDoublyDescending(DoublyLinkedList list)
        {
            list.SortDescending();
        }
    }
}
