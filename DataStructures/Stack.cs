namespace DataStructures
{
    /// <summary>
    /// Stack implements a last in-first out style list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Stack<T>
    {
        private Node? _first;
        private int _size; 

        /// <summary>
        /// Node represents a node in the Stack.
        /// </summary>
        private class Node
        {
            internal readonly T Value;
            internal Node? Next;

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

            if (_size == 1) _first = null;

            _first = nodeToRemove.Next;

            _size--;

            return nodeToRemove.Value;
        }

        /// <summary>
        /// Gets the size of the stack.
        /// </summary>
        /// <returns>The number of nodes in the stack.</returns>
        internal int Length()
        {
            return _size;
        }
    }
}
