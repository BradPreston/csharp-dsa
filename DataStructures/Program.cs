namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> ER = new PriorityQueue<string> ();
            ER.Enqueue("common cold", 5);
            ER.Enqueue("gunshot wound", 1);
            ER.Enqueue("high fever", 4);
            ER.Enqueue("broken arm", 2);
            ER.Enqueue("glass in foot", 3);

            string? removed = ER.Dequeue();
        }
    }
}