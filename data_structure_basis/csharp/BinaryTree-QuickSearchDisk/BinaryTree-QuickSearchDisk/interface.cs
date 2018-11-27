using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree_QuickSearchDisk
{
    interface IQueue<T>
    {
        void EnQueue(T elem);
        T DeQueue();
        T GetFront();
        int GetLength();
        bool IsEmpty();
        void Clear();
        bool IsFull();
    }
    interface IBankQueue : IQueue<int>
    {
        int GetCallnumber();
    }

}
