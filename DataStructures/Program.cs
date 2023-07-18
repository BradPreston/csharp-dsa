namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(20);

            List<int> treeValues = tree.DFSInOrder();

            foreach(int value in treeValues)
            {
                Console.WriteLine(value);
            }
        }
    }
}