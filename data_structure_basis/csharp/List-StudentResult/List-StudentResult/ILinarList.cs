using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_StudentResult
{
    interface  ILinarList<T>
    {
        void InsertNode(T a, int i);
        void DeleteNode(int i);
        T SearchNode(int i);
        T SearchNode(T value);
        int GetLength();
        void Clear();
        bool IsEmpty();
    }
}
