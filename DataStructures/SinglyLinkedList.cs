using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class SinglyLinkedList<T>
    {
        private Node? Head = null;
        private Node? Tail = null;
        internal int Length = 0;

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

            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            Length++;
        }

        internal T? Pop()
        {
            if (Head == null) return default;

            Node current = Head;
            Node newTail = current;

            while (current.Next != null)
            {
                newTail = current;
                current = current.Next;
            }

            Tail = newTail;
            Tail.Next = null;
            Length--;

            if (Length == 0)
            {
                Head = null;
                Tail = null;
            }

            return current.Value;
        }

        internal void Unshift(T value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            Length++;
        }

        internal T? Shift()
        {
            if (Head == null) return default;

            Node current = Head;
            Head = current.Next;

            Length--;

            if (Length == 0)
            {
                Head = null;
                Tail = null;
            }

            return current.Value;
        }

        internal T? Get(int index)
        {
            if (index < 0 || index >= Length) return default;
            if (Head == null) return default;

            int counter = 0;
            Node current = Head;

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
            if (index < 0 || index >= Length) return;
            if (Head == null) return;

            int counter = 0;
            Node current = Head;

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
