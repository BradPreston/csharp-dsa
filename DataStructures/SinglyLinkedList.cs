﻿using System;
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
            internal Node(T Value)
            {
                this.Value = Value;
            }
        }

        internal void Push(T Value)
        {
            Node newNode = new Node(Value);

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
    }
}
