using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Priority Queue stores values in a min binary heap like structure based on priority
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class PriorityQueue<T>
    {
        private readonly List<Node> _values = new();

        private class Node
        {
            internal readonly T Value;
            internal readonly int Priority;
            // could add a time variable to check which node was added first if two nodes have the same priority

            internal Node(T value, int priority)
            {
                this.Value = value;
                this.Priority = priority;
            }
        }

        /// <summary>
        /// Adds a node to the beginning of the priority queue
        /// </summary>
        /// <param name="value"></param>
        /// <param name="priority"></param>
        internal void Enqueue(T value, int priority)
        {
            Node newNode = new Node(value, priority);
            _values.Add(newNode);
            int index = _values.Count - 1;
            BubbleUp(Convert.ToDecimal(index), _values[index]);
        }

        /// <summary>
        /// Removes the first node from the priority queue
        /// </summary>
        /// <returns>The min priority of the priority queue</returns>
        internal T? Dequeue()
        {
            // if the priority queue is empty, return the default for T
            if (_values.Count == 0) return default;

            // set min to the first node in the priority queue
            Node min = _values[0];
            // set the end to the last node in the priority queue
            Node end = _values.Last();
            // remove the end node from the list
            _values.RemoveAt(_values.Count - 1);

            // if the priority queue is not empty
            if (_values.Count > 0)
            {
                // set the new min as the end node in the priority queue
                _values[0] = end;
                // send the new end down the priority queue until it finds a fitting parent
                SinkDown();
            }

            return min.Value;
        }

        /// <summary>
        /// BubbleUp swaps the parent node with the inserted node if the inserted node has a greater priority than its parent.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        private void BubbleUp(decimal index, Node element)
        {
            while (index > 0)
            {
                // find the parent of the current node
                decimal findParent = (index - 1) / 2;
                // get the index of the parent
                decimal parentIndex = Math.Floor(findParent);
                // grab the parent from the values list
                Node parent = _values[(int)parentIndex];

                // if the current node has a greater priority than the parent, break out. No need to swap
                if (element.Priority >= parent.Priority) { break; }

                // swap the parent and the current element
                _values[(int)parentIndex] = element;
                _values[(int)index] = parent;

                // set the index to the parentIndex to check if the parent needs to swap with its new parent
                index = parentIndex;
            }
        }

        /// <summary>
        /// SinkDown takes the new root after dequeue and sends it down the priority queue until it finds a fitting parent.
        /// </summary>
        private void SinkDown()
        {
            int index = 0;
            int length = _values.Count;
            Node element = _values[0];

            while (true)
            {
                // in a list, the left child is always at (index * 2) + 1, or + 2 for right child
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;

                Node? leftChildValue = null;

                // set swap to -1 if it hasn't been swapped yet
                int swap = -1;

                // if the index of the left child is less than the length of the priority queue
                if (leftChildIndex < length)
                {
                    // set the left child value to the left child in the list
                    leftChildValue = _values[leftChildIndex];

                    // if the priority of the left child is smaller than the current root
                    if (leftChildValue.Priority < element.Priority)
                    {
                        // set swap to the index of the left child
                        // this will be used later to set a parent
                        swap = leftChildIndex;
                    }
                }

                // if the index of the right child is less than the length of the priority queue
                if (rightChildIndex < length)
                {
                    // set the right child value to the value of the right child in the list
                    Node? rightChildValue = _values[rightChildIndex];

                    // if swap is -1 (aka, no left child index) and the priority of the left child is smaller than the
                    // priority of the current root
                    // OR
                    // the left child does have a value and the priority of the right child is less than the priority
                    // of the left child
                    if (
                        (swap == -1 && rightChildValue.Priority < element.Priority) ||
                        (swap != -1 && leftChildValue != null && rightChildValue.Priority < leftChildValue.Priority)
                    )
                    {
                        // set the swap to the right child
                        swap = rightChildIndex;
                    }
                }

                // if the right or left child index are out of bounds or have a lesser priority than their parent already, nothing to change
                if (swap == -1) break;

                // set the value at the current index to the value at the index of the swap (right or left child index)
                _values[index] = _values[swap];
                // the value at the swap index (right or left child index) becomes our new root value
                _values[swap] = element;
                // set the index as the swap index and start the loop over
                index = swap;
            }
        }
    }
}
