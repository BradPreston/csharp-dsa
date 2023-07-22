using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Stack<T>
    {
        private class Node
        {
            internal T Value;
            internal Node? Next;

            internal Node(T Value)
            {
                this.Value = Value;
            }
        }
    }
}
