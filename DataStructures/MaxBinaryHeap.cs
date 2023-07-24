using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// MaxBinaryHeap stores nodes in a tree where the children are smaller than the parent.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class MaxBinaryHeap<T>
    {
        private readonly List<T> _values = new();

        /// <summary>
        /// Inserts a node into the Heap.
        /// </summary>
        /// <param name="value"></param>
        internal void Insert(T value)
        {
            _values.Add(value);
            int index = _values.Count - 1;
            BubbleUp(Convert.ToDecimal(index), _values[index]);
        }

        /// <summary>
        /// ExtractMax removes the root from the heap.
        /// </summary>
        /// <returns>The max value of the heap</returns>
        internal T? ExtractMax()
        {
            // if the heap is empty, return the default for T
            if (_values.Count == 0) return default;

            // set max to the first element in the heap
            T max = _values[0];
            // set the end to the last element in the heap
            T end = _values.Last();
            // remove the end element from the list
            _values.RemoveAt(_values.Count - 1);

            // if the heap is not empty
            if (_values.Count > 0)
            {
                // set the new max as the end value in the heap
                _values[0] = end;
                // send the new end down the heap until it finds a fitting parent
                SinkDown();
            }
            
            return max;
        }

        /// <summary>
        /// BubbleUp swaps the parent node with the inserted node if the inserted node is larger than the parent.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        private void BubbleUp(decimal index, T element)
        {
            while (index > 0)
            {
                // find the parent of the current node
                decimal findParent = (index - 1) / 2;
                // get the index of the parent
                decimal parentIndex = Math.Floor(findParent);
                // grab the parent from the values list
                T parent = _values[(int)parentIndex];

                // if the current node is smaller than the parent, break out. No need to swap
                if (IsLessThan(element, parent)) { break; }

                // swap the parent and the current element
                _values[(int)parentIndex] = element;
                _values[(int)index] = parent;

                // set the index to the parentIndex to check if the parent needs to swap with its new parent
                index = parentIndex;
            }
        }

        /// <summary>
        /// SinkDown takes the new root after extract and sends it down the heap until it finds a fitting parent.
        /// </summary>
        private void SinkDown()
        {
            int index = 0;
            int length = _values.Count;
            T element = _values[0];

            while (true)
            {
                // in a list, the left child is always at (index * 2) + 1, or + 2 for right child
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;

                T? leftChildValue = default;

                // set swap to -1 if it hasn't been swapped yet
                int swap = -1;

                // if the index of the left child is less than the length of the heap
                if (leftChildIndex < length)
                {
                    // set the left child value to the left child in the list
                    leftChildValue = _values[leftChildIndex];

                    // if the new root is smaller than the left child value
                    if (IsLessThan(element, leftChildValue))
                    {
                        // set swap to the index of the left child
                        // this will be used later to set a parent
                        swap = leftChildIndex;
                    }
                }

                // if the index of the right child is less than the length of the heap
                if (rightChildIndex < length)
                {
                    // set the right child value to the value of the right child in the list
                    T? rightChildValue = _values[rightChildIndex];

                    // if swap is -1 (aka, no left child index) and the new root value is less than the right child value
                    // OR
                    // the left child does have a value and the that value is less than the right child's value
                    // 
                    // we want the swap index to be the larger of the two left or right values. so if left has a value 
                    // and it's smaller than right's value, set the swap to the right child index. otherwise, leave it as
                    // the left child's index.
                    if (
                        (swap == -1 && IsLessThan(element, rightChildValue)) ||
                        (swap != -1 && leftChildValue != null && IsLessThan(leftChildValue, rightChildValue))
                    )
                    {
                        // set the swap to the right child
                        swap = rightChildIndex;
                    }
                }

                // if the right or left child index are out of bounds or are smaller than their parent already, nothing to change
                if (swap == -1) break;

                // set the value at the current index to the value at the index of the swap (right or left child index)
                _values[index] = _values[swap];
                // the value at the swap index (right or left child index) becomes our new root value
                _values[swap] = element;
                // set the index as the swap index and start the loop over
                index = swap;
            }
        }

        /// <summary>
        /// IsLessThan checks if value1 is less than value2. 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns>True if value1 is less than value2; otherwise, false.</returns>
        private static bool IsLessThan(T value1, T value2)
        {
            int result = Comparer<T>.Default.Compare(value1, value2);
            return result <= 0;
        }
    }
}
