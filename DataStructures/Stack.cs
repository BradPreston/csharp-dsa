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
    }
}
