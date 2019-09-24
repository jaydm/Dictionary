using System;
using System.Collections.Generic;
using System.Text;

namespace GenericImplementation
{
    class Entry<K, V>
    {
        K key;
        V values;
        Entry<K, V> next;
        public Entry(K key, V values)
        {
            this.key = key;
            this.values = values;
            this.next = null;

        }
        public K Key { get { return key; } }
        public V Value { get { return values; } set { values = value; } }
        public Entry<K, V> Next { get { return next; } set { next = value; } }
    }
}
