using System;
using System.Collections.Generic;
using System.Text;

namespace GenericImplementation
{
    class Dictionarys<K, V>
    {
        static int TABLE_SIZE = 127;
        Entry<K, V>[] table;
        int count;

        public Dictionarys()
        {
            table = new Entry<K, V>[TABLE_SIZE];
        }
        public Dictionarys(int capacity)
        {
            table = new Entry<K, V>[capacity];
        }
        public void Insert(K key, V value)
        {
            int hashf = Math.Abs(key.GetHashCode() % table.Length);
            //int hashf = key.GetHashCode() & 0x7FFFFFFF;  // another good way; 0x7FFFFFF remove the - sign;
            //hashf %= table.Length;
            Entry<K, V> entry = new Entry<K, V>(key, value);
            Entry<K, V> doesExist = table[hashf]; //marking
            if (doesExist == null)
            {
                table[hashf] = new Entry<K, V>(key, value); // insert if null
                count++;
            }
            else
            {
                // check if key already exist
                while (doesExist != null)
                {
                    if (doesExist.Key.Equals(key))
                    {
                        doesExist.Value = value;
                        return;
                    }
                    doesExist = doesExist.Next; // to the next guy
                }

                count++;

            }
        }
        public V Get(K key)
        {
            int hashf = Math.Abs(key.GetHashCode() % table.Length);
            Entry<K, V> slot = table[hashf];
            if (!key.Equals(slot.Key) && slot == null) // if the key doesnt exist here
            {
                throw new ArgumentException("Key doesnt exist");
            }
            while (slot != null)
            {
                if (key.Equals(slot.Key))
                {
                    return slot.Value;
                }

                slot = slot.Next;
            }
            return default(V);
        }
        public bool exist(K key)
        {
            return Get(key) != null;
        }
        public int Count { get { return this.count; } }

        public V this[K key]
        {
            get { return Get(key); }
            set { Insert(key, value); }
        }
        public void Clear()
        {
            table = new Entry<K, V>[table.Length]; // all null
            count = 0; // set count to zero
        }
        public void Remove(K key)
        {
            int hashf = Math.Abs(key.GetHashCode() % table.Length);
            Entry<K, V> slot = table[hashf];
            if (!key.Equals(slot.Key) && slot == null) // if the key doesnt exist here
            {
                throw new ArgumentException("Key doesnt exist");
            }
            while (slot != null)
            {
                if (key.Equals(slot.Key))
                {

                }
            }
        }
    }
}
