using System;

namespace GenericImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionarys<string, int> dic = new Dictionarys<string, int>();
            dic.Insert("A", 567);
            dic.Insert("B", 897);
            dic.Insert("N", 8898);
            dic.Insert("C", 6665);
          //  
           // dic.Clear();
            Console.WriteLine(dic.exist("A"));
            Console.WriteLine(dic.Count);
        }
    }
}
