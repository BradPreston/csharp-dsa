using System.Data;

namespace DataStructures
{
    internal class Graph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacencyList = new Dictionary<T, List<T>>();
        
        /// <summary>
        /// Adds a vertex to the Graph.
        /// </summary>
        /// <param name="key">The key to add to the Graph.</param>
        /// <exception cref="ArgumentException">The key already exists.</exception>
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
        /// <exception cref="KeyNotFoundException">Either <c>vertex1</c> or <c>vertex2</c> were not found as a key.</exception>
        internal void AddEdge(T vertex1, T vertex2)
        {
            if (!_adjacencyList.TryGetValue(vertex1, out List<T>? vertex1Array))
                throw new KeyNotFoundException($"Key: \"{vertex1}\" was not found.");
            
            if (!_adjacencyList.TryGetValue(vertex2, out List<T>? vertex2Array))
                throw new KeyNotFoundException($"Key: \"{vertex2}\" was not found.");

            if (vertex1Array?.IndexOf(vertex2) > 0 || vertex2Array?.IndexOf(vertex1) > 0) return;
            
            vertex1Array?.Add(vertex2);
            vertex2Array?.Add(vertex1);
        }

        /// <summary>
        /// Removes an edge between two vertices.
        /// </summary>
        /// <param name="vertex1">The first vertex.</param>
        /// <param name="vertex2">The second vertex.</param>
        /// <exception cref="KeyNotFoundException"><c>vertex1</c> or <c>vertex2</c> were not found as keys.</exception>
        /// <exception cref="DataException">No edge between <c>vertex1</c> or <c>vertex2</c>.</exception>
        internal void RemoveEdge(T vertex1, T vertex2)
        {
            if (!_adjacencyList.TryGetValue(vertex1, out List<T>? vertex1Array))
                throw new KeyNotFoundException($"Key: \"{vertex1}\" was not found.");
            
            if (!_adjacencyList.TryGetValue(vertex2, out List<T>? vertex2Array))
                throw new KeyNotFoundException($"Key: \"{vertex2}\" was not found.");

            if (vertex1Array?.IndexOf(vertex2) < 0 || vertex2Array?.IndexOf(vertex1) < 0)
                throw new DataException($"No edge between \"{vertex2}\" and \"{vertex1}\"");

            vertex1Array?.Remove(vertex2);
            vertex2Array?.Remove(vertex1);
        }

        /// <summary>
        /// Removes a vertex from the Graph.
        /// </summary>
        /// <param name="vertex">The key to remove.</param>
        /// <exception cref="KeyNotFoundException">The key does not exist.</exception>
        internal void RemoveVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
                throw new KeyNotFoundException($"Key: \"{vertex}\" was not found.");
            
            foreach (List<T> value in _adjacencyList.Values)
            {
                value.Remove(vertex);
            }

            _adjacencyList.Remove(vertex);
        }
    }
}