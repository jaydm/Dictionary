using System;

namespace GenericImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionarys<int, int> dic = new Dictionarys<int, int>();
            dic.Insert(2, 567);
            dic.Insert(4, 897);
            dic.Insert(7, 8898);
            dic.Insert(6, 6665);
            //  
            // dic.Clear();
            Console.WriteLine(   dic.Remove(2));
            Console.WriteLine(dic[4]);
            Console.WriteLine(dic.Count);
        }
    }
}
