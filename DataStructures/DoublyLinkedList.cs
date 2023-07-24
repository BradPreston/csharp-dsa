using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class DoublyLinkedList<T>
    {
        private Node? _head = null;
        private Node? _tail = null;
        private int _length = 0;

        private class Node
        {
            internal readonly T Value;
            internal Node? Next = null;
            internal Node? Prev = null;
            internal Node(T value)
            {
                this.Value = value;
            }
        }

        internal void Push(T value)
        {
            Node newNode = new Node(value);

            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }

            _length++;
        }

        internal T? Pop()
        {
            if (_tail == null) return default;

            Node currentTail = _tail;

            if (_length == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _tail = _tail.Prev;

                if (_tail == null) return default;
                
                _tail.Next = null;
            }

            _length--;

            return currentTail.Value;
        }
        
        internal void Unshift(T value)
        {
            Node newNode = new Node(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }

            _length++;
        }
        
        internal T? Shift()
        {
            if (_head == null) return default;

            Node current = _head;
            _head = current.Next;

            if (_head == null) return default;
            
            _head.Prev = null;

            _length--;

            if (_length == 0)
            {
                _head = null;
                _tail = null;
            }

            return current.Value;
        }
    }
}
