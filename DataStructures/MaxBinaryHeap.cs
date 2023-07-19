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
        private readonly List<T> values = new();

        /// <summary>
        /// Inserts a node into the Heap.
        /// </summary>
        /// <param name="value"></param>
        internal void Insert(T value)
        {
            values.Add(value);
            int index = values.Count - 1;
            BubbleUp(Convert.ToDecimal(index), values[index]);
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
                T parent = values[(int)parentIndex];

                // if the current node is smaller than the parent, break out. No need to swap
                if (IsLessThan(element, parent)) { break; }

                // swap the parent and the current element
                values[(int)parentIndex] = element;
                values[(int)index] = parent;

                // set the index to the parentIndex to check if the parent needs to swap with its new parent
                index = parentIndex;
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
