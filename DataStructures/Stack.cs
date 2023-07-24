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
        private Node? _first = null;
        private Node? _last = null;
        private int _size = 0; 

        /// <summary>
        /// Node represents a node in the Stack.
        /// </summary>
        private class Node
        {
            internal readonly T Value;
            internal Node? Next = null;

            internal Node(T value)
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// Push adds a node to the beginning of the stack.
        /// </summary>
        /// <param name="value"></param>
        internal void Push(T value)
        {
            Node newNode = new Node(value);

            if (_size == 0)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = _first;
                _first = newNode;
            }

            _size++;
        }

        /// <summary>
        /// Pop removes the first node from the stack.
        /// </summary>
        /// <returns>Returns the value of the removed node; or the default of <c>T</c> if empty.</returns>
        internal T? Pop()
        {
            if (_first == null) return default;

            Node nodeToRemove = _first;

            if (_size == 1) _last = null;

            _first = nodeToRemove.Next;

            _size--;

            return nodeToRemove.Value;
        }
    }
}
