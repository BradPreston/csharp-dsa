﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class SinglyLinkedList<T>
    {
        private Node? _head = null;
        private Node? _tail = null;
        private int _length = 0;

        private class Node
        {
            internal T Value;
            internal Node? Next = null;
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
                _tail = newNode;
            }

            _length++;
        }

        internal T? Pop()
        {
            if (_head == null) return default;

            Node current = _head;
            Node newTail = current;

            while (current.Next != null)
            {
                newTail = current;
                current = current.Next;
            }

            _tail = newTail;
            _tail.Next = null;
            _length--;

            if (_length == 0)
            {
                _head = null;
                _tail = null;
            }

            return current.Value;
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
                _head = newNode;
            }

            _length++;
        }

        internal T? Shift()
        {
            if (_head == null) return default;

            Node current = _head;
            _head = current.Next;

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

            while(counter >= index)
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
    }
}
