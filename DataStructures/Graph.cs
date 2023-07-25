namespace DataStructures
{
    internal class Graph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacencyList = new Dictionary<T, List<T>>();
        internal void AddVertex(T key)
        {
            if (!_adjacencyList.TryAdd(key, new List<T>()))
                throw new ArgumentException($"Key: \"{key}\" already exists.");
        }

        /// <summary>
        /// Adds a two way connection between two vertices.
        /// </summary>
        /// <param name="vertex1">The first vertex.</param>
        /// <param name="vertex2">The second vertex.</param>
        /// <exception cref="KeyNotFoundException"><c>vertex1</c> or <c>vertex2</c> were not found as keys.</exception>
        internal void AddEdge(T vertex1, T vertex2)
        {
            if (!_adjacencyList.TryGetValue(vertex1, out List<T>? vertex1Array))
                throw new KeyNotFoundException($"Key: \"{vertex1}\" was not found.");
            
            if (!_adjacencyList.TryGetValue(vertex2, out List<T>? vertex2Array))
                throw new KeyNotFoundException($"Key: \"{vertex2}\" was not found.");
            
            vertex1Array?.Add(vertex2);
            vertex2Array?.Add(vertex1);
        }

        internal void RemoveEdge(T vertex1, T vertex2)
        {
            if (!_adjacencyList.TryGetValue(vertex1, out List<T>? vertex1Array))
                throw new KeyNotFoundException($"Key: \"{vertex1}\" was not found.");
            
            if (!_adjacencyList.TryGetValue(vertex2, out List<T>? vertex2Array))
                throw new KeyNotFoundException($"Key: \"{vertex2}\" was not found.");

            vertex1Array?.Remove(vertex2);
            vertex2Array?.Remove(vertex1);
        }
    }
}