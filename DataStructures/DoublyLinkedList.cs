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
            internal T Value;
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
        
        internal T? Get(int index)
        {
            if (index < 0 || index >= _length) return default;
            if (_head == null) return default;

            int counter = 0;
            Node current = _head;

            while(counter < index)
            {
                if (current.Next == null) break;

                current = current.Next;
                counter++;
            }

            return current.Value;
        }
        
        internal void Set(int index, T value)
        {
            if (index < 0 || index >= _length) return;
            if (_head == null) return;

            int counter = 0;
            Node current = _head;

            while(counter < index)
            {
                if (current.Next == null) break;
                current = current.Next;
                counter++;
            }

            current.Value = value;
        }
        
        internal void Insert(int index, T value)
        {
            if (index < 0 || index > _length) return;
            if (index == _length)
            {
                this.Push(value);
                return;
            }

            if (index == 0)
            {
                this.Unshift(value);
                return;
            }

            Node newNode = new Node(value);
            
            int counter = 0;
            Node? nodeBeforeInsert = _head;

            while(counter < index)
            {
                if (nodeBeforeInsert?.Next == null) break;

                nodeBeforeInsert = nodeBeforeInsert.Next;
                counter++;
            }

            if (nodeBeforeInsert == null) return;

            
            newNode.Next = nodeBeforeInsert.Next;

            if (nodeBeforeInsert.Next == null) return;
            
            nodeBeforeInsert.Next.Prev = newNode;
            newNode.Prev = nodeBeforeInsert;
            nodeBeforeInsert.Next = newNode;

            _length++;
        }
    }
}
