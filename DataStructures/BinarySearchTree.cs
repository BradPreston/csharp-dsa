using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class BinarySearchTree<T>
    {

        private Node? root = null;

        /// <summary>
        /// Node is the class that holds the binary tree node.
        /// </summary>
        internal class Node
        {
            internal T value;
            internal Node? left = null;
            internal Node? right = null;

            public Node(T value)
            {
                this.value = value;
            }
        }

        /// <summary>
        /// isLessThan checks if value1 is less than value2. 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns>True if value1 is less than value2; otherwise, false.</returns>
        private bool isLessThan(T value1, T value2)
        {
            int result = Comparer<T>.Default.Compare(value1, value2);
            return result < 0;
        }

        /// <summary>
        /// Insert adds a new node to the tree.
        /// </summary>
        /// <param name="value"></param>
        internal void Insert(T value)
        {
            Node newNode = new Node(value);

            if (newNode.value == null) { return; }

            // if no root is set, set the root to the newNode
            if (root == null)
            {
                root = newNode;
                return;
            }

            bool traversing = true;
            Node currentNode = root;

            while (traversing)
            {
                // if the newNode value is the same as the currentNode value, break out of the loop. No duplicates allowed
                if (newNode.value.Equals(currentNode.value)) { break; }

                // if the newNode value is less than the currentNode value, move to the left edge
                if (isLessThan(newNode.value, currentNode.value))
                {
                    // set the node on the left edge to the newNode if the left edge is null
                    if (currentNode.left == null)
                    {
                        currentNode.left = newNode;
                        break;
                    }

                    // set the currentNode to the currentNode's left edge value if the left edge is not null
                    currentNode = currentNode.left;
                }
                else
                {
                    // set the node on the right edge to the newNode if the right edge is null
                    if (currentNode.right == null)
                    {
                        currentNode.right = newNode;
                        break;
                    }

                    // set the currentNode to the currentNode's right edge value if the left right is not null
                    currentNode = currentNode.right;
                }
            }
        }

        /// <summary>
        /// Find searches through the tree to see if a value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if a node is found with the same value; otherwise, false.</returns>
        internal bool Find(T value)
        {
            // if root is null or the root value is null or null is passed as a value, there is nothing to find. 
            if (root == null || root.value == null || value == null)
            {
                return false;
            }

            // if the root value equals the value passed into Find
            if (root.value.Equals(value))
            {
                return true;
            }

            bool traversing = true;
            Node currentNode = root;

            while (traversing)
            {

                // if the value is the same as the value in the current node
                if (value.Equals(currentNode.value))
                {
                    return true;
                }

                // if the value is less than the currentNode value, move to the left edge
                if (isLessThan(value, currentNode.value))
                {
                    // if there is a value on currentNode's left edge
                    if (currentNode.left != null)
                    {
                        // set the currentNode to be the currentNode's left edge node
                        currentNode = currentNode.left;
                        continue;
                    }
                }
                else
                {
                    // if there is a value on currentNode's right edge
                    if (currentNode.right != null)
                    {
                        // set the currentNode to be the currentNode's right edge node
                        currentNode = currentNode.right;
                        continue;
                    }
                }

                // if none of these conditions are met, we've hit the last leaf on the tree. Cannot traverse further.
                traversing = false;
            }

            // no node was found with the value passed into Find
            return false;
        }

        /// <summary>
        /// Breadth First Search visits each node from the top down by "row".
        /// </summary>
        /// <returns></returns>
        internal List<T> BreadthFirstSearch()
        {
            Node? node = root;
            List<T> data = new List<T>();
            List<Node> queue = new List<Node>();

            if (node == null)
            {
                return data;
            }

            queue.Add(node);

            while (queue.Count > 0)
            {
                node = queue.FirstOrDefault();
                queue.RemoveAt(0);
                
                if (node == null) { break; }

                data.Add(node.value);

                if (node.left != null)
                {
                    queue.Add(node.left);
                }

                if (node.right != null)
                {
                    queue.Add(node.right);
                }
            }

            return data;
        }

        private void PreOrderTraverse(List<T> visited, Node node)
        {
            if (node.value == null) { return; }

            visited.Add(node.value);

            if (node.left != null)
            {
                PreOrderTraverse(visited, node.left);
            }

            if (node.right != null)
            {
                PreOrderTraverse(visited, node.right);
            }
        }

        private void PostOrderTraverse(List<T> visited, Node node)
        {
            if (node.value == null) { return; }

            if (node.left != null)
            {
                PostOrderTraverse(visited, node.left);
            }

            if (node.right != null)
            {
                PostOrderTraverse(visited, node.right);
            }

            visited.Add(node.value);
        }

        private void InOrderTraverse(List<T> visited, Node node)
        {
            if (node.value == null) { return; }

            if (node.left != null)
            {
                InOrderTraverse(visited, node.left);
            }

            visited.Add(node.value);

            if (node.right != null)
            {
                InOrderTraverse(visited, node.right);
            }
        }

        /// <summary>
        /// DFS (Depth First Search) Pre Order visits each node starting from the left edge going right. Preorder aka start left, go right.
        /// </summary>
        /// <returns></returns>
        internal List<T> DFSPreOrder()
        {
            List<T> visited = new List<T>();
            if (root == null) { return visited; }
            PreOrderTraverse(visited, root);
            return visited;
        }

        internal List<T> DFSPostOrder()
        {
            List<T> visited = new List<T>();
            if (root == null) { return visited; };
            PostOrderTraverse(visited, root);
            return visited;
        }

        /// <summary>
        /// DFS (Depth First Search) In Order visits each node as it appears from the left to the right. Similar to how a scan would work from left to right.
        /// </summary>
        /// <returns></returns>
        internal List<T> DFSInOrder()
        {
            List<T> visited = new List<T>();
            if (root == null) { return visited; };
            InOrderTraverse(visited, root);
            return visited;
        }
    }
}

