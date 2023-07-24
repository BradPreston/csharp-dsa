namespace DataStructures
{
    /// <summary>
    /// Represents a list with links that go both directions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DoublyLinkedList<T>
    {
        private Node? _head;
        private Node? _tail;
        private int _length;

        private class Node
        {
            internal T Value;
            internal Node? Next;
            internal Node? Prev;
            internal Node(T value)
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// Push adds a node to the end of the list.
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// Pop removes the last node in the list.
        /// </summary>
        /// <returns>The value of the popped node; or the default type for <typeparamref name="T"/> if empty.</returns>
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
                // check if tail is null again after reassigning it's value
                if (_tail == null) return default;
                
                _tail.Next = null;
            }

            _length--;

            return currentTail.Value;
        }
        
        /// <summary>
        /// Unshift adds a node to the beginning of the list.
        /// </summary>
        /// <param name="value"></param>
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
        
        /// <summary>
        /// Shift removes the first node from the list.
        /// </summary>
        /// <returns>The value of the shifted node; or the default type for <typeparamref name="T"/> if empty.</returns>
        internal T? Shift()
        {
            if (_head == null) return default;

            Node current = _head;
            _head = current.Next;

            // check if _head is null again after reassigning it's value
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
        
        /// <summary>
        /// Gets a value of a node by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The value of the found node; or the default type for <typeparamref name="T"/> if not found.</returns>
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
        
        /// <summary>
        /// Finds a node by index and replaces it's value with a new value.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
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
        
        /// <summary>
        /// Insert adds a node to the list after the index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
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
            
            if (nodeBeforeInsert?.Next == null) return;

            Node nodeAfterInsert = nodeBeforeInsert.Next;
            
            nodeAfterInsert.Prev = newNode;
            newNode.Next = nodeAfterInsert;
            nodeBeforeInsert.Next = newNode;
            newNode.Prev = nodeBeforeInsert;

            _length++;
        }
        
        /// <summary>
        /// Removes a node from the list by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The value of the removed node; or the default type for <typeparamref name="T"/> if not found.</returns>
        internal T? Remove(int index)
        {
            if (index < 0 || index > _length) return default;
            if (index == _length) return this.Pop();
            if (index == 0) return this.Shift();

            int counter = 0;
            Node? nodeBeforeRemove = _head;

            while(counter < index - 1)
            {
                if (nodeBeforeRemove?.Next == null) break;

                nodeBeforeRemove = nodeBeforeRemove.Next;
                counter++;
            }

            Node? nodeToRemove = nodeBeforeRemove?.Next;

            if (nodeToRemove == null || nodeBeforeRemove == null) return default;

            Node? nodeAfterRemove = nodeToRemove.Next;
            if (nodeAfterRemove == null) return default;
            
            nodeBeforeRemove.Next = nodeAfterRemove;
            nodeAfterRemove.Prev = nodeBeforeRemove;

            _length--;

            return nodeToRemove.Value;
        }
    }
}
