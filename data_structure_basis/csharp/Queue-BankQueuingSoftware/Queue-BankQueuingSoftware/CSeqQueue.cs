using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue_BankQueuingSoftware
{
    class CSeqQueue<T>:IQueue<T>
    {
        private int maxsize;
        private T[] data;
        private int front;
        private int rear;
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        public int Maxsize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }
        public int Front
        {
            get { return front; }
            set { front = value; }
        }
        public int Rear
        {
            get { return rear; }
            set { rear = value; }
        }
        public CSeqQueue() { }
        public CSeqQueue(int size)
        {
            data = new T[size];
            maxsize = size;
            front = rear = -1;
        }
        public void EnQueue(T elem)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full");
                return;
            }
            rear = (rear + 1) % maxsize;
            data[rear] = elem;
        }
        public T DeQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            front = (front + 1) % maxsize;
            return data[front];
        }
        public T GetFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empy");
                return default(T);
            }
            return data[(front + 1) % maxsize];
        }
        public int GetLength()
        {
            return (rear - front + maxsize) % maxsize;
        }
        public bool IsFull()
        {
            if ((front == -1 && rear == maxsize - 1) || (rear + 1) % maxsize == front)
                return true;
            else
                return false;
        }
        public void Clear()
        {
            front = rear = -1;
        }
        public bool IsEmpty()
        {
            if (front == rear)
                return true;
            else
                return false;
        }
    }
    class CSeqBankQueue : CSeqQueue<int>, IBankQueue
    {
        private int callnumber;
        public int Callnumber
        {
            get { return callnumber; }
            set { callnumber = value; }
        }
        public CSeqBankQueue() { }
        public CSeqBankQueue(int size) : base(size) { }
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
