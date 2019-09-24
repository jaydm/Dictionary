using System;
using System.Collections.Generic;
using System.Text;

namespace GenericImplementation
{
  class Dictionarys<K, V>
  {
    // (jdm) this is not actually the table size since you
    // allow for the dictionary to be created with a specific
    // capacity - it is just the default
    private static int DEFAULT_TABLE_SIZE = 127;
    private Entry<K, V>[] table; // (jdm) hide direct access to the internal structure
    private int count; // (jdm) hide direct access to the internals

    public Dictionarys()
    {
      table = new Entry<K, V>[DEFAULT_TABLE_SIZE];
    }

    public Dictionarys(int capacity)
    {
      table = new Entry<K, V>[capacity];
    }

    // (jdm) convenience function
    private int getSlot(K key)
    {
      return Math.Abs(key.GetHashCode() % table.Length);
    }

    public void Insert(K key, V value)
    {
      Console.WriteLine("Inserting value: {1} in key: {0}", key, value);

      int hashf = getSlot(key);

      Console.WriteLine("Slot number: {0}", hashf);

      //int hashf = key.GetHashCode() & 0x7FFFFFFF;  // another good way; 0x7FFFFFF remove the - sign;
      //hashf %= table.Length;

      Entry<K, V> entry = new Entry<K, V>(key, value);

      // (jdm) changing the name to be more descriptive
      // Entry<K, V> doesExist = table[hashf]; //marking
      Entry<K, V> slot = table[hashf];

      if (slot == null) // (jdm) no entries in the slot yet...
      {
        Console.WriteLine("Empty slot...set table index to entry");

        table[hashf] = entry;

        count++;
      }
      else
      {
        // check if key already exist
        Console.WriteLine("Non-empty slot...search for existing key...");

        while (slot != null)
        {
          if (slot.Key.Equals(key))
          {
            Console.WriteLine("Key found...overwrite value");

            slot.Value = value;

            return;
          }

          slot = slot.Next; // to the next guy
        }

        // (jdm) the key was not found...so, add it to the beginning of the
        // list and fix the pointer
        Console.WriteLine("Key not found...insert entry at beginning of collision list...");

        Console.WriteLine("Original first entry in slot: key = {0} value = {1}", table[hashf].Key, table[hashf].Value);
        Console.WriteLine("New value should be: {0}: ", entry.Value);

        entry.Next = table[hashf];
        table[hashf] = entry;

        Console.WriteLine("New value in first entry of slot: {0}", table[hashf].Value);

        Entry<K, V> secondEntry = table[hashf].Next;

        Console.WriteLine("Second entry: key = {0} value = {1}", secondEntry.Key, secondEntry.Value);

        count++;
      }
    }

    public V Get(K key)
    {
      int hashf = getSlot(key); // (jdm) Use convenience function
      Entry<K, V> pointer = table[hashf]; // (jdm) renaming for style only

      // (jdm) cannot test this here - the matching key could be somewhere
      // other than the beginning of the collision list
      /*
      if (!key.Equals(pointer.Key)) // if the key doesnt exist here
      {
        throw new ArgumentException("Key doesnt exist");

      }
      */

      while (pointer != null)
      {
        if (key.Equals(pointer.Key))
        {
          return pointer.Value;
        }

        pointer = pointer.Next;
      }

      // (jdm) shouldn't this also return key does not exist?
      // return default(V);
      throw new ArgumentException("Key doesnt exist");
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

    // (jdm) here is where there should be some direction on
    // the behaviour of the function when attempting to
    // remove a non-existant key
    // either: silently fail or throw an exception
    //
    // it looks like you want to throw an exception
    // so there are some changes below
    public void Remove(K key)
    {
      int hashf = getSlot(key);

      Entry<K, V> slot = table[hashf];
      Entry<K, V> prev = null;

      // (jdm) there is nothing in the entire slot - so the key cannot be in the list
      if (slot == null)
      {
        throw new ArgumentException("Cannot remove...key does not exist");
      }

      // (jdm) the original would report failure if the selected key
      // was not the first entry in the collision list
      /*
            if (!key.Equals(slot.Key) && slot == null) // if the key doesnt exist here
            {
              throw new ArgumentException("Key doesnt exist");
            }
      */

      // (jdm) the original code was stepping through all of the entries
      // in the selected slot - but was not checking for a key match
      // 
      // then it remove the last entry in the list...there is no way
      // of being certain that was actually a match for the key you are
      // searching for. in fact, you could be removing the wrong key and
      // leaving the one you want to remove
      /*
      while (slot != null)
      {
        prev = slot;
        slot = slot.Next;
      }

      if (prev != null)
      {
        table[hashf] = null; // set required key to null
      }
      */

      while (slot != null)
      {
        if (slot.Key.Equals(key))
        {
          if (prev != null)
          {
            prev.Next = slot.Next; // (jdm) change next pointer of the previous entry to the entry after current
          }
          else
          {
            // (jdm) prev == null...so, this is the first entry in the list
            table[hashf] = slot.Next;
          }

          count--;

          return;
        }

        prev = slot;
        slot = slot.Next;
      }

      // (jdm) since the expected behaviour is to throw an exception when
      // trying to remove a non-existant key...we need to throw an exception
      // because the key was not already removed
      // also, we should not decrement the count
      /*
      count--;

      return;
      */
      
      throw new ArgumentException("Cannot remove...key does not exist");
    }
  }
}
