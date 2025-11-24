using System;

namespace LinkedListSorter.App.LinkedList
{
    public class Node
    {
        // Stores the integer value for this node
        public int Data { get; set; }

        // Reference to the next node in the list
        public Node Next { get; set; }

        public Node(int value)
        {
            //Store value in Data and initialize Next
            Data = value;
            Next = null;
        }
    }
}
