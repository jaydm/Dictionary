using System;

namespace GenericImplementation
{
  class Program
  {
    static void Main(string[] args)
    {
      Dictionarys<int, int> dic = new Dictionarys<int, int>();

      dic.Insert(2, 567);

      Console.WriteLine("What is in dictionary for key = 2...{0}", dic.Get(2));

      dic.Insert(4, 897);

      Console.WriteLine("What is in dictionary for key = 4...{0}", dic.Get(4));

      dic.Insert(4, 1897);

      Console.WriteLine("What is in dictionary for key = 4...{0}", dic.Get(4));

      // (jdm) forcing an instance where there is more than one
      // value in the same slot
      // (you can only know this if you know the implementation details)
      dic.Insert(4 + 127, 1000);

      Console.WriteLine("What is in dictionary for key = 131 (4 + 127)...{0}", dic.Get(4 + 127));
      Console.WriteLine("Is the value for key = 4 still 1897?...{0}", dic.Get(4));

      dic.Insert(7, 8898);

      Console.WriteLine("What is in dictionary for key = 7...{0}", dic.Get(7));

      dic.Insert(6, 6665);

      Console.WriteLine("What is in dictionary for key = 6...{0}", dic.Get(6));

      // dic.Clear();
      // (jdm) can't console out the result of dic.Remove - it returns void
      // Console.WriteLine(dic.Remove(2));

      Console.WriteLine("Dictionary size: {0}", dic.Count);
      Console.WriteLine("Does an entry for key = 2 exist? {0}", dic.exist(2));
      Console.WriteLine("Removing the value for key = 2");

      dic.Remove(2);

      try
      {
        Console.WriteLine("How about now? {0}", dic.exist(2));
      }
      catch (ArgumentException e)
      {
        Console.WriteLine("There is no longer a value for key = 2: {0}", e.Message);
      }

      Console.WriteLine("Dictionary size after removal: {0}", dic.Count);

      // (jdm) this is not quite what you need - you should use dic.Get(4)
      // but...it seems to work. must be some kind of language overloading
      Console.WriteLine("Dictionary[4]: {0}", dic[4]);

      Console.WriteLine("Dictionary Get(4): {0}", dic.Get(4));
      Console.WriteLine("Dictionary Get(4 + 127): {0}", dic.Get(4 + 127));
      Console.WriteLine("Dictionary Count: {0}", dic.Count);
    }
  }
}
