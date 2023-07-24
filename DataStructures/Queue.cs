namespace DataStructures
{
    /// <summary>
    /// Queue represents a first in-first out (FIFO) data structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Queue<T>
    {
        private Node? _first ;
        private Node? _last ;
        internal int Size;

        /// <summary>
        /// Node represents a node in the queue. 
        /// </summary>
        private class Node
        {
            internal readonly T Value;
            internal Node? Next ;

            public Node(T value)
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// Enqueue adds a node to the end of the queue.
        /// </summary>
        /// <param name="value"></param>
        internal void Enqueue(T value)
        {
            Node newNode = new Node(value);

            // check if _last is null since we're adding to the end of the queue.
            if (_last == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else 
            {
                _last.Next = newNode;
                _last = newNode;
            }

            Size++;
        }

        /// <summary>
        /// Dequeue returns the first node in the queue.
        /// </summary>
        /// <returns>The value of the removed node; throws error if queue is empty.</returns>
        internal T? Dequeue()
        {
            // check if _first is null since we're removing from the beginning of the queue.
            if (_first == null) return default;

            Node nodeToRemove = _first;

            if (_first == _last)
            {
                _last = null;
            }

            _first = _first.Next;

            Size--;

            return nodeToRemove.Value;
        }
    }
}
