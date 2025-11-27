using System;
using System.Collections.Generic;

namespace LinkedListSorter.App.LinkedList
{
    /// <summary>
    /// Doubly linked list implementation that supports insert, remove, traversal, and sorting.
    /// </summary>
    public class DoublyLinkedList
    {
        // Reference to the first node in the list
        public DoublyNode? head { get; private set; }

        // Reference to the last node in the list
        public DoublyNode? tail { get; private set; }

        // Number of nodes currently in the list
        public int count { get; private set; }

        public DoublyLinkedList()
        {
            // TODO: initialize Head, Tail, and Count.
            
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Inserts a new value at the front of the list.
        /// </summary>
        public void AddFirst(int value)
        {
            // create new node with value
            DoublyNode newNode = new DoublyNode(value);

            if (head is null)
            {
               head = newNode;
               tail = newNode; 
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            
            // increment Count
            count++;
        }

        /// <summary>
        /// Inserts a new value at the end of the list.
        /// </summary>
        public void AddLast(int value)
        {
            // Pseudocode:
            // create new node with value
            DoublyNode newNode = new DoublyNode(value);

            if (head is null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            
            // increment Count
            count++;
        }

        /// <summary>
        /// Removes the first element of the list if it exists.
        /// Returns true if a node was removed.
        /// </summary>
        public bool RemoveFirst()
        {
            // Pseudocode:
            if (head is null)
                return false;
            // if list is empty:
            //     return false
            //
            // if there is only one node set Head and Tail to null
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                // move Head to Head.Next set new Head.Previous to null
                head = head.Next;
                head.Previous = null;
            }
            // decrement Count
            count--;       
            
            // return true
            return true;
        }

        /// <summary>
        /// Removes the last element of the list if it exists.
        /// Returns true if a node was removed.
        /// </summary>
        public bool RemoveLast()
        {
            // Pseudocode:
            // if list is empty:
            //     return false
            //
            // if there is only one node:
            //     set Head and Tail to null
            // else:
            //     move Tail to Tail.Previous
            //     set new Tail.Next to null
            //
            // decrement Count
            // return true
            return false;
        }

        /// <summary>
        /// Removes the first node with the specified value.
        /// Returns true if a node was removed.
        /// </summary>
        public bool Remove(int value)
        {
            // Pseudocode:
            // start from Head
            // while current is not null:
            //     if current.Data equals value:
            //         if current is Head:
            //             call RemoveFirst logic
            //         else if current is Tail:
            //             call RemoveLast logic
            //         else:
            //             link current.Previous.Next to current.Next
            //             link current.Next.Previous to current.Previous
            //         decrement Count
            //         return true
            //     move to next node
            // if value not found, return false
            return false;
        }

        /// <summary>
        /// Returns an array of values by walking from Head to Tail.
        /// </summary>
        public int[] ToArrayForward()
        {
            // Pseudocode:
            // create a dynamic list of ints
            // start from Head
            // while current is not null:
            //     add current.Data to list
            //     move to current.Next
            // convert dynamic list to array and return
            return Array.Empty<int>();
        }

        /// <summary>
        /// Returns an array of values by walking from Tail to Head.
        /// </summary>
        public int[] ToArrayBackward()
        {
            // Pseudocode:
            // create a dynamic list of ints
            // start from Tail
            // while current is not null:
            //     add current.Data to list
            //     move to current.Previous
            // convert dynamic list to array and return
            return Array.Empty<int>();
        }

        /// <summary>
        /// Sorts the list values in ascending order.
        /// Implementation can use merge sort or any stable list sort.
        /// </summary>
        public void SortAscending()
        {
            // Pseudocode option:
            // 1. Convert list to array using ToArrayForward.
            // 2. Sort the array with Array.Sort.
            // 3. Walk the nodes again from Head and copy sorted values back.
            //
            // Or fully linked list merge sort:
            // 1. If list is empty or has one node, return.
            // 2. Use GetMiddle to split into two halves.
            // 3. Recursively sort each half.
            // 4. Merge the two sorted halves into a new sorted list and update Head and Tail.
        }

        /// <summary>
        /// Sorts the list values in descending order.
        /// </summary>
        public void SortDescending()
        {
            // Pseudocode option:
            // 1. Call SortAscending to get ascending order.
            // 2. Reverse the list by swapping Next and Previous for each node
            //    and swapping Head and Tail.
            //
            // Or:
            // 1. Convert to array.
            // 2. Sort ascending, then reverse the array.
            // 3. Write values back into the list nodes.
        }

        /// <summary>
        /// Helper to clear the list. Optional for tests or reuse.
        /// </summary>
        public void Clear()
        {
            // Pseudocode:
            // set Head and Tail to null
            // set Count to 0
            // let garbage collector reclaim nodes
        }
    }
}
