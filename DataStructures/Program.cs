namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaxBinaryHeap<int> heap = new MaxBinaryHeap<int>();

            heap.Insert(41);
            heap.Insert(39);
            heap.Insert(33);
            heap.Insert(18);
            heap.Insert(27);
            heap.Insert(12);
            heap.Insert(55);
            heap.Insert(1);
            heap.Insert(45);
            heap.Insert(199);
        }
    }
}