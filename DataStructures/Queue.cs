using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Queue represents a first in-first out (FIFO) data structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Queue<T>
    {
        private Node? First = null;
        private Node? Last = null;
        internal int Size = 0;

        /// <summary>
        /// Node represents a node in the queue. 
        /// </summary>
        private class Node
        {
            internal T Value;
            internal Node? Next = null;

            public Node(T value)
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// Enqueue adds a node to the end of the queue.
        /// </summary>
        /// <param name="value"></param>
        internal void Enqueue(T value)
        {
            Node newNode = new Node(value);

            // check if Last is null since we're adding to the end of the queue.
            if (Last == null)
            {
                First = newNode;
                Last = newNode;
            }
            else 
            {
                Last.Next = newNode;
                Last = newNode;
            }

            Size++;
        }

        /// <summary>
        /// Dequeue returns the first node in the queue.
        /// </summary>
        /// <returns>The value of the removed node; throws error if queue is empty.</returns>
        /// <exception cref="Exception"></exception>
        internal T Dequeue()
        {
            // check if First is null since we're removing from the beginning of the queue.
            if (First == null)
            {
                throw new Exception("cannot remove from an empty queue");
            }

            Node nodeToRemove = First;

            if (First == Last)
            {
                Last = null;
            }

            First = First.Next;

            Size--;

            return nodeToRemove.Value;
        }
    }
}
