using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Stack implements a last in-first out style list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Stack<T>
    {
        private Node? First = null;
        private Node? Last = null;
        internal int Size = 0; 

        /// <summary>
        /// Node represents a node in the Stack.
        /// </summary>
        private class Node
        {
            internal T Value;
            internal Node? Next = null;

            internal Node(T Value)
            {
                this.Value = Value;
            }
        }

        /// <summary>
        /// Push adds a node to the beginning of the stack.
        /// </summary>
        /// <param name="Value"></param>
        internal void Push(T Value)
        {
            Node newNode = new Node(Value);

            if (Size == 0)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
            }

            Size++;
        }

        /// <summary>
        /// Pop removes the first node from the stack.
        /// </summary>
        /// <returns>Returns the value of the removed node; or the default of <c>T</c> if empty.</returns>
        internal T? Pop()
        {
            if (First == null) return default;

            Node nodeToRemove = First;

            if (Size == 1) Last = null;

            First = nodeToRemove.Next;

            Size--;

            return nodeToRemove.Value;
        }
    }
}
