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
        public Node? head { get; private set; }
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
            if (head is null) return Array.Empty<int>();

            // First, determine the size of the linked list
            Node current = head;
            var count = 0;
            while (current is not null)
            {
                count++;
                current = current.Next;
            }
            
            // create array of determined size
            int[] arrayResult = new int[count];

            // Traverse the linked list again and copy elements to the array
            current = head;
            int index = 0;
            while (current is not null)
            {
                arrayResult[index] = current.Data;
                current = current.Next;
                index++;
            }

            return arrayResult;
        }

        // Sort the list in ascending order
        public Node SortAscending(Node head)
        {
            // TODO: Implement ascending sort logic
            if (head is null || head.Next is null) return head;

            // Split the list into two halves
            Node mid = GetMiddle(head), 
            secondHalf = mid.Next;
            mid.Next = null; // Break the link

            // recursively sort the two halves
            Node sortedFirstHalf = SortAscending(head);
            Node sortedSecondHalf = SortAscending(secondHalf);

            // Merge the Sorted Halves
            return MergedSortedLists(sortedFirstHalf, sortedSecondHalf);

        }

        // Sort the list in descending order
        public void SortDescending()
        {
            // TODO: Implement descending sort logic
        }
        
        private Node GetMiddle(Node head)
        {
            throw new NotImplementedException();
        }

        private Node MergedSortedLists(Node sortedFirstHalf, Node sortedSecondHalf)
        {
            throw new NotImplementedException();
        }

        
    }
}
