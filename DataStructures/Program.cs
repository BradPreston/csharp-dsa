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

            int extracted1 = heap.ExtractMax();
            int extracted2 = heap.ExtractMax();
            int extracted3 = heap.ExtractMax();
            int extracted4 = heap.ExtractMax();
            int extracted5 = heap.ExtractMax();
            int extracted6 = heap.ExtractMax();
        }
    }
}