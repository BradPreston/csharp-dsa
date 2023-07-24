namespace DataStructures
{
    internal class BinarySearchTree<T>
    {

        private Node? _root;

        /// <summary>
        /// Node is the class that holds the binary tree node.
        /// </summary>
        internal class Node
        {
            internal T Value;
            internal Node? Left;
            internal Node? Right;

            public Node(T value)
            {
                this.Value = value;
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
            return result < 0;
        }

        /// <summary>
        /// Insert adds a new node to the tree.
        /// </summary>
        /// <param name="value"></param>
        internal void Insert(T value)
        {
            Node newNode = new Node(value);

            if (newNode.Value == null) { return; }

            // if no _root is set, set the _root to the newNode
            if (_root == null)
            {
                _root = newNode;
                return;
            }

            Node currentNode = _root;

            while (true)
            {
                // if the newNode value is the same as the currentNode value, break out of the loop. No duplicates allowed
                if (newNode.Value.Equals(currentNode.Value)) { break; }

                // if the newNode value is less than the currentNode value, move to the Left edge
                if (IsLessThan(newNode.Value, currentNode.Value))
                {
                    // set the node on the Left edge to the newNode if the Left edge is null
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }

                    // set the currentNode to the currentNode's Left edge value if the Left edge is not null
                    currentNode = currentNode.Left;
                }
                else
                {
                    // set the node on the Right edge to the newNode if the Right edge is null
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }

                    // set the currentNode to the currentNode's Right edge value if the Left Right is not null
                    currentNode = currentNode.Right;
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
            // if _root is null or the _root value is null or null is passed as a value, there is nothing to find. 
            if (_root == null || _root.Value == null || value == null)
            {
                return false;
            }

            // if the _root value equals the value passed into Find
            if (_root.Value.Equals(value))
            {
                return true;
            }

            bool traversing = true;
            Node currentNode = _root;

            while (traversing)
            {

                // if the value is the same as the value in the current node
                if (value.Equals(currentNode.Value))
                {
                    return true;
                }

                // if the value is less than the currentNode value, move to the Left edge
                if (IsLessThan(value, currentNode.Value))
                {
                    // if there is a value on currentNode's Left edge
                    if (currentNode.Left != null)
                    {
                        // set the currentNode to be the currentNode's Left edge node
                        currentNode = currentNode.Left;
                        continue;
                    }
                }
                else
                {
                    // if there is a value on currentNode's Right edge
                    if (currentNode.Right != null)
                    {
                        // set the currentNode to be the currentNode's Right edge node
                        currentNode = currentNode.Right;
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
            Node? node = _root;
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

                data.Add(node.Value);

                if (node.Left != null)
                {
                    queue.Add(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Add(node.Right);
                }
            }

            return data;
        }

        private static void PreOrderTraverse(List<T> visited, Node node)
        {
            if (node.Value == null) { return; }

            visited.Add(node.Value);

            if (node.Left != null)
            {
                PreOrderTraverse(visited, node.Left);
            }

            if (node.Right != null)
            {
                PreOrderTraverse(visited, node.Right);
            }
        }

        private static void PostOrderTraverse(List<T> visited, Node node)
        {
            if (node.Value == null) { return; }

            if (node.Left != null)
            {
                PostOrderTraverse(visited, node.Left);
            }

            if (node.Right != null)
            {
                PostOrderTraverse(visited, node.Right);
            }

            visited.Add(node.Value);
        }

        private static void InOrderTraverse(List<T> visited, Node node)
        {
            if (node.Value == null) { return; }

            if (node.Left != null)
            {
                InOrderTraverse(visited, node.Left);
            }

            visited.Add(node.Value);

            if (node.Right != null)
            {
                InOrderTraverse(visited, node.Right);
            }
        }

        /// <summary>
        /// DFS (Depth First Search) Pre Order visits each node starting from the Left edge going Right. Preorder aka start Left, go Right.
        /// </summary>
        /// <returns></returns>
        internal List<T> DfsPreOrder()
        {
            List<T> visited = new List<T>();
            if (_root == null) { return visited; }
            PreOrderTraverse(visited, _root);
            return visited;
        }

        internal List<T> DfsPostOrder()
        {
            List<T> visited = new List<T>();
            if (_root == null) return visited;
            PostOrderTraverse(visited, _root);
            return visited;
        }

        /// <summary>
        /// DFS (Depth First Search) In Order visits each node as it appears from the Left to the Right. Similar to how a scan would work from Left to Right.
        /// </summary>
        /// <returns></returns>
        internal List<T> DfsInOrder()
        {
            List<T> visited = new List<T>();
            if (_root == null) return visited;
            InOrderTraverse(visited, _root);
            return visited;
        }
    }
}

