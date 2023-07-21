namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable(17);
            hashTable.Set("maroon", "#800000");
            hashTable.Set("yellow", "#FFFF00");
            hashTable.Set("olive", "#80800");
            hashTable.Set("salmon", "#FA8072");
            hashTable.Set("lightcoral", "#F08080");
            hashTable.Set("mediumvioletred", "#C71585");
            hashTable.Set("plum", "#DDA0DD");
            hashTable.Set("purple", "#DDA0DD");
            hashTable.Set("violet", "#DDA0DD");

            var values = hashTable.Values();
            var keys = hashTable.Keys();

        }
    }
}