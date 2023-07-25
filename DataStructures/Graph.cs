namespace DataStructures
{
    internal class Graph<T> where T : notnull
    {
        private readonly Dictionary<T, T[]> _adjacencyList = new Dictionary<T, T[]>();
        internal void AddVertex(T key)
        {
            _adjacencyList.Add(key, Array.Empty<T>());
        }
    }
}