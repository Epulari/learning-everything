using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue_BankQueuingSoftware
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
