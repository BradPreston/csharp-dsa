namespace DataStructures
{
    internal class Graph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacencyList = new Dictionary<T, List<T>>();
        internal void AddVertex(T key)
        {
            // TryAdd doesn't add a new key if an exact match key exists.
            // returns true or false instead of throwing an exception
            _adjacencyList.TryAdd(key, new List<T>());
        }

        /// <summary>
        /// Adds a two way connection between two vertices.
        /// </summary>
        /// <param name="vertex1">The first vertex.</param>
        /// <param name="vertex2">The second vertex.</param>
        /// <exception cref="KeyNotFoundException"><c>vertex1</c> or <c>vertex2</c> were not found as keys.</exception>
        internal void AddEdge(T vertex1, T vertex2)
        {
            if (_adjacencyList.TryGetValue(vertex1, out List<T>? vertex1Array))
            {
                vertex1Array?.Add(vertex2);
            }
            else
            {
                throw new KeyNotFoundException($"Key: \"{vertex1}\" was not found.");
            }

            if (_adjacencyList.TryGetValue(vertex2, out List<T>? vertex2Array))
            {
                vertex2Array?.Add(vertex1);
            }
            else
            {
                throw new KeyNotFoundException($"Key: \"{vertex2}\" was not found.");
            }
        }
    }
}