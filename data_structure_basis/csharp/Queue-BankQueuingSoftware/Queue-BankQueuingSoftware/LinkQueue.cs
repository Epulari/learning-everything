using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue_BankQueuingSoftware
{
    class QueueNode<T>
    {
        private T data;
        private QueueNode<T> next;
        public QueueNode (T val,QueueNode <T> p)
        {
            data=val;
            next =p;
        }
        public QueueNode (QueueNode <T> p)
        {
            next =p;
        }
        public QueueNode (T val)
        {
            data=val;
            next =null;
        }
        public QueueNode ()
        {
            data=default (T);
            next =null;
        }
        public T Data
        {
            get {return data;}
            set {data=value ;}
        }
        public QueueNode <T> Next
        {
            get{return next;}
            set{next=value ;}
        }
    }
    class LinkQueue<T>:IQueue <T>
    {
        private int size;
        private QueueNode<T> front;
        private QueueNode<T> rear;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public QueueNode<T> Front
        {
            get { return front; }
            set { front = value; }
        }
        public QueueNode<T> Rear
        {
            get { return rear; }
            set { rear = value; }
        }
        public LinkQueue()
        {
            front = rear = null;
            size = 0;
        }
        public void EnQueue(T item)
        {
            QueueNode<T> q = new QueueNode<T>(item);
            if (IsEmpty())
            {
                front = q;
                rear = q;
            }
            else
            {
                rear.Next = q;
                rear = q;
            }
            ++size;
        }
        public T DeQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
                return default(T);
            }
            QueueNode<T> p = front;
            front = front.Next;
            if (front == null)
                rear = null;
            --size;
            return p.Data;
        }
        public T GetFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
                return default(T);
            }
            return front.Data;
        }
        public int GetLength()
        {
            return size;
        }
        public void Clear()
        {
            front = rear = null;
            size = 0;
        }
        public bool IsEmpty()
        {
            if ((front == rear) && (size == 0))
                return true;
            else
                return false;
        }
        public bool IsFull()
        {
            return false;
        }
    }
    class LinkBankQueue : LinkQueue<int>, IBankQueue
    {
        private int callnumber;
        public int Callnumber
        {
            get { return callnumber; }
            set { callnumber = value; }
        }
        public int GetCallnumber()
        {
            if ((IsEmpty()) && callnumber == 0)
                callnumber = 1;
            else
                callnumber++;
            return callnumber;
        }
    }
}
