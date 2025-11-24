using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace LinkedListSorter.App.LinkedList
{
    public class SinglyLinkedList
    {
        // Reference to the first node in the list
        public Node head { get; private set; }
        // Reference to the currentNode
        public int Size = 0;

        public SinglyLinkedList()
        {
            // TODO: Initialize Head to null
            head = null;

        }

        // Insert a value at the front of the list
        public void AddAtFront(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;

        }
        // Insert a value into the end of the list
        public void InsertAtEnd(int value)
        {
            // TODO: Implement insertion logic
            Node newNode = new Node(value);
            if (head == null)
                head = newNode;
            
            Node current = head;
            while (current.Next is not null)// using the is not null instead of != null offers an advantage when dealing with nullable reference types and operator overloading. Learned this on .NET Tips on YouTube
            {
                current = current.Next;
            }
            current.Next = newNode;     
            
        }

        // Convert the linked list into an array for testing and display
        public int[] ToArray()
        {
            // TODO: Walk the list, collect values, and return as array
            return Array.Empty<int>();
        }

        // Sort the list in ascending order
        public void SortAscending()
        {
            // TODO: Implement ascending sort logic
        }

        // Sort the list in descending order
        public void SortDescending()
        {
            // TODO: Implement descending sort logic
        }
    }
}
