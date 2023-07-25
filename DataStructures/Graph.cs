namespace DataStructures
{
    internal class Graph<T> where T : notnull
    {
        private readonly Dictionary<T, T[]> _adjacencyList = new Dictionary<T, T[]>();
        internal void AddVertex(T key)
        {
            // TryAdd doesn't add a new key if an exact match key exists.
            // returns true or false instead of throwing an exception
            _adjacencyList.TryAdd(key, Array.Empty<T>());
        }
    }
}