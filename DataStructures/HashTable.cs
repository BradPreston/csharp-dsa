using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// HashTable stores key value pairs in a table
    /// </summary>
    internal class HashTable
    {
        private readonly List<string[]>[] keyMap;

        /// <summary>
        /// Constructor sets the size of the keyMap array
        /// </summary>
        /// <param name="size"></param>
        internal HashTable(int size = 53)
        {
            keyMap = new List<string[]>[size];
        }

        /// <summary>
        /// Hash creates a number hash based on the char code of each character in key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>An integer to be used as a retrieval index</returns>
        private int Hash(string key)
        {
            int total = 0;
            int prime = 31;

            for (int i = 0; i < Math.Min(key.Length, 100); i++)
            {
                char c = key[i];
                int value = (int)c - 96;
                // multiply the total by the prime to prevent collisions
                total = (total * prime + value) % keyMap.Length;
            }

            return total;
        }

        /// <summary>
        /// Set adds a key value pair to the HashMap
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        internal void Set(string key, string value)
        {
            // get the index of the key from the map
            int index = Hash(key);
            // create a new key value variable
            List<string[]> kv = new();

            // if there isn't a value in the keyMap at this index
            if (keyMap.GetValue(index) == null)
            {
                // set the value to the new empty key value variable
                keyMap.SetValue(kv, index);
            }

            // set the keyValue variable to the value returned at the index
            kv = (List<string[]>)keyMap.GetValue(index);
            // add a new key value pair to the index in the keyMap
            kv.Add(new string[] { key, value });

            // set the value at the index of the key value pair array
            keyMap.SetValue(kv, index);
        }

        /// <summary>
        /// Get returns a value from the key passed in
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The value that matches the key or null if no value is found</returns>
        internal string? Get(string key)
        {
            // get the index of the key from the map
            int index = Hash(key);

            // if the value at the index is null, return null
            if (keyMap.GetValue(index) == null) return null;

            // get the list of key value pairs at the index
            List<string[]> valuesAtIndex = (List<string[]>)keyMap.GetValue(index);

            // loop over each key value pair
            foreach(string[] kv in valuesAtIndex)
            {
                // if the key of key value matches the key passed in to Get
                if ((string)kv.GetValue(0) == key)
                {
                    // return the key
                    return (string)kv.GetValue(1);
                }
            }

            // if there are no matches, return null
            return null;
        }

        /// <summary>
        /// Values returns all the unique values in the HashMap
        /// </summary>
        /// <returns>A list of values or an empty list if there are no values</returns>
        internal List<string> Values()
        {
            List<string> values = new();

            // loop over all the entries in the keyMap
            foreach(List<string[]> entry in keyMap)
            {
                if (entry == null) continue;

                // loop over the kv pairs in the entry
                foreach(string[] kv in entry)
                {
                    // if the values array already contains the value, skip
                    if (values.Contains(kv[1])) continue;
                    values.Add(kv[1]);
                }
            }

            return values;
        }

        /// <summary>
        /// Keys returns all the unique keys in the HashMap
        /// </summary>
        /// <returns>A list of keys or an empty list if there are no keys</returns>
        internal List<string> Keys()
        {
            List<string> keys = new();

            // loop over all the entries in the keyMap
            foreach (List<string[]> entry in keyMap)
            {
                if (entry == null) continue;

                // loop over the kv pairs in the entry
                foreach (string[] kv in entry)
                {
                    // if the keys array already contains the key, skip
                    if (keys.Contains(kv[0])) continue;
                    keys.Add(kv[0]);
                }
            }

            return keys;
        }
    }
}
