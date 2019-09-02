using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interface
{
    public interface IMyList
    {
        void Add(string[] arr);

        void Remove(int n);

        int Used { get; }
    }
}
