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
    }
}
