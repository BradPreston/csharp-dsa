using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Stack<T>
    {
        private Node? First = null;
        private Node? Last = null;
        internal int Size = 0; 

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
