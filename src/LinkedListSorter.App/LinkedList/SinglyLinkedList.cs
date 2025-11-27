using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            {
                head = newNode;
                return;
            }
            // Otherwise, walked to the last node.
            Node current = head;
            while (current.Next is not null)// using the is not null instead of != null offers an advantage when dealing with nullable reference types and operator overloading. Learned this on .NET Tips on YouTube
            {
                current = current.Next;
            }

            // Attach new node at the end;
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
        public void SortAscending()
        {
            if (head is null || head.Next is null)
                return;

            head = SortAscendingInternal(head);
        }
        public Node SortAscendingInternal(Node node)
        {
            // TODO: Implement ascending sort logic
            if (node is null || node.Next is null) 
                return node;

            // Split the list into two halves
            Node mid = GetMiddle(node), 
            secondHalf = mid.Next;
            mid.Next = null; // Break the link

            // recursively sort the two halves
            Node sortedFirstHalf = SortAscendingInternal(node);
            Node sortedSecondHalf = SortAscendingInternal(secondHalf);

            // Merge the Sorted Halves
            return MergedAscending(sortedFirstHalf, sortedSecondHalf);

        }


        // Sort the list in descending order
        public void SortDescending()
        {
            if (head is null || head.Next is null)
                return;
            head = SortDescendingInternal(head);
        }
        public Node SortDescendingInternal(Node node)
        {
            // TODO: Implement descending sort logic
            if (node is null || node.Next is null)
                return node;
            
            Node  middle = GetMiddle(node), nextToMiddle = middle.Next;
            middle.Next = null;

            Node left = SortDescendingInternal(node), 
                 right = SortDescendingInternal(nextToMiddle);
            
            return MergedDescending(left, right);
        }

        

        // Helper method for finding the middle of the linked list and using
        // fast and slow pointers

        private Node GetMiddle(Node head)
        {
            if (head is null)
                return null;
            Node slow = head, fast = head.Next;
            // Fast pointer moves two steps, slow pointer moves one step
            // When fast reaches the end, slow is at the middle
            while (fast.Next is not null && fast.Next.Next is not null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        // Helper method to merge two sorted lists into one ascending list
        private Node MergedAscending(Node list1, Node list2)
        {
            // Create a dummy head for the merged list
            Node dummyHead = new Node(0);
            Node current = dummyHead;

            // Iterate while both lists have nodes
            while (list1 is not null && list2 is not null)
            {
                // Compare data and append the smaller node to the merged list
                if (list1.Data <= list2.Data)
                {
                    current.Next = list1;
                    list1 = list1.Next;
                }
                else
                {
                    current.Next = list2;
                    list2 = list2.Next;
                }
                current = current.Next;
            } 

            // Attach the remaining nodes of whichever list is not empty
            if (list1 is not null)
                current.Next = list1;
            if (list2 is not null)
                current.Next = list2;
            
            // The actual head is the next of the dummy node
            return dummyHead.Next;
        }        

        private Node MergedDescending(Node left, Node right)
        {
            Node dummyHead = new Node(0);
            Node current = dummyHead;

            while (left is not null && right is not null)
            {
                if (left.Data >= right.Data)
                {
                    current.Next = left;
                    left = left.Next;
                }
                else
                {
                    current.Next = right;
                    right = right.Next;
                }
                current = current.Next;

            }

            if (left is not null)
                current.Next = left;
            if (right is not null)
                current.Next = right;
            
            return dummyHead.Next;
        }
    }
}
