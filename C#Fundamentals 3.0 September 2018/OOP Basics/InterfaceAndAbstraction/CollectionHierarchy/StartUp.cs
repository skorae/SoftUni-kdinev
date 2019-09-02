using System;
using CollectionHierarchy.Lists;
using CollectionHierarchy.Interface;
using System.Text;

namespace CollectionHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            AddCollections collection = new AddCollections();
            AddRemoveCollection addRemove = new AddRemoveCollection();
            MyLists myList = new MyLists();

            collection.Add(arr);
            addRemove.Add(arr);
            myList.Add(arr);
            addRemove.Remove(n);
            myList.Remove(n);
        }
    }
}
