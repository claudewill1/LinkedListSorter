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
                tail!.Next = newNode;
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
                head!.Previous = null;
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
            
            
            // check for empty list, return false if null
            if (head is null)
                return false;
            // check for single node; if true set head and tail to null
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail!.Previous;
                tail!.Next = null;
            }       
            count--;
            return true;
            
        }

        /// <summary>
        /// Removes the first node with the specified value.
        /// Returns true if a node was removed.
        /// </summary>
        public bool Remove(int value)
        {
            // Pseudocode:
            // start from Head
            DoublyNode? current = head;
            while (current is not null)
            {
                if (current.Data == value)
                {
                    // if this is the head node, delegate to RemoveFirst
                    if (current == head)
                    {
                        RemoveFirst();
                    
                    }
                    
                    // If this is the tail node, delegate to removeLast
                    if (current == tail)
                    {
                        RemoveLast();
                    }
                    // Node is in the middle
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                    
                    count--;
                    return true;
                                                
                }
                    
                // move to next node before continuing
                current = current.Next;   
            }
                
              return false;  
        }
            
            
    

        /// <summary>
        /// Returns an array of values by walking from Head to Tail.
        /// </summary>
        public int[] ToArrayForward()
        {
            // Pseudocode:
            // create a dynamic list of ints
            List<int> values = new List<int>();
            // start from Head
            DoublyNode? current = head;

            while (current is not null)
            {
                values.Add(current.Data);
                current = current.Next;
            }
            return values.ToArray();

            
        }

        /// <summary>
        /// Returns an array of values by walking from Tail to Head.
        /// </summary>
        public int[] ToArrayBackward()
        {
            // Pseudocode:
            // create a dynamic list of ints
            List<int> values = new List<int>();
            DoublyNode? current = tail;
            while (current is not null)
            {
                values.Add(current.Data);
                current = current.Previous;
            }
            return values.ToArray();
            
        }

        /// <summary>
        /// Sorts the list values in ascending order.
        /// Implementation can use merge sort or any stable list sort.
        /// </summary>
        public void SortAscending()
        {
            if (head is null || head.Next is null)
                return;
            
            head = MergeSort(head);
            
            // Update tail reference
            DoublyNode? current = head;
            while (current!.Next is not null)
                current = current.Next;
            tail = current;
        
        }       
        private DoublyNode MergeSort(DoublyNode head)
        {
            if (head is null || head.Next is null)
                return head;
            // Find the middle of the list
            DoublyNode middle = GetMiddle(head), secondHalf = middle.Next;
            middle.Next = null;
            if (secondHalf is not null)
                secondHalf.Previous = null;
            // Recursively sort the two halves
            DoublyNode left = MergeSort(head),
                right = MergeSort(secondHalf!); 
            // Merge the sorted halves
            return MergeSortedLists(left, right);
    // Break list into two independent lists
        }

        private DoublyNode MergeSortedLists(DoublyNode left, DoublyNode right)
        {
            
            DoublyNode result = null!, current = null!; 
            if (left is null)
                return right;
            if (right is null)
                return left;
            
            // Choose smaller head value
            if (left.Data <= right.Data)
            {
                result = left;
                left = left.Next!;
            }
            else
            {
                result = right;
                right = right.Next!;
            }
            current = result;
            current.Previous = null;

            // Merge remaining nodes
            while (left is not null && right is not null)
            {
                if (left.Data <= right.Data)
                {
                    current.Next = left;
                    left.Previous = current;
                    current = left;
                    left = left.Next!;
                }
                else
                {
                    current.Next = right;
                    right.Previous = current;
                    current = right;
                    right = right.Next!;
                }
            }
            // Append remaining nodes
            if (left is not null)
            {
                current.Next = left;
                left.Previous = current;
            }
            else if (right is not null)
            {
                current.Next = right;
                right.Previous = current;
            }
            return result;
        }


        private DoublyNode GetMiddle(DoublyNode head)
        {
            DoublyNode slow = head, fast = head;
            while (fast.Next is not null && fast.Next.Next is not null)
            {
                slow = slow.Next!;
                fast = fast.Next.Next;
            }
            return slow;
        }
    public void SortDescending()
        {
            // Pseudocode option:
            if (head is null || head.Next is null)
                return;
            // 1. Call SortAscending to get ascending order.
            SortAscending();
            
            // 2. Reverse the list.

            DoublyNode? current = head;
            DoublyNode? temp = null;
            while (current is not null)
            {
                // swap next and previous 
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                // move to next node (which is previous before swap)
                current = current.Previous;
            }
            // After reversing, temp holds the last swapped node
            // which is the new head
            if (temp is not null)
                head = temp.Previous;
                        
            // Update tail reference
            current = head;
            while (current!.Next is not null)
                current = current.Next;
            tail = current;
        }


        /// <summary>
        /// Sorts the list values in descending order.
        /// </summary>
        

        /// <summary>
        /// Helper to clear the list. Optional for tests or reuse.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
