using System;

namespace LinkedListSorter.App.LinkedList
{
    /// <summary>
    /// Represents a single node in a doubly linked list.
    /// </summary>
    public class DoublyNode
    {
        // Stores the value for this node
        public int Data;

        // Reference to the next node in the list
        public DoublyNode? Next;

        // Reference to the previous node in the list
        public DoublyNode? Previous;

        public DoublyNode(int value)
        {
            Data = value;
            Next = null;
            Previous = null;
        }
    }
}
