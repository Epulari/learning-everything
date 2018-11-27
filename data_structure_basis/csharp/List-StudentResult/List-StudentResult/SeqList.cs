using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_StudentResult
{
    public class SeqList<T>:ILinarList <T>
    {
        private int maxsize;
        private T[] data;
        private int length;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Maxsize
        {
            get { return maxsize ; }
            set { maxsize  = value; }
        }
        public SeqList(int size)
        {
            maxsize = size;
            data = new T[maxsize];
            length = 0;
        }
        public void InsertNode(T a)
        {
            if (IsFull())
            {
                Console.WriteLine("List is full");
                return;
            }
            data[length] = a;
            length++;
        }
        public void InsertNode(T a, int i)
        {
            if (IsFull())
            {
                Console.WriteLine("List is full");
                return;
            }
            if (i < 1 || i > length + 1)
            {
                Console.WriteLine("Position is error!");
                return;
            }
            else
            {
                for (int j = length - 1; j >= i - 1; j--)
                {
                    data[j + 1] = data[j];
                }
                data[i - 1] = a;
            }
            length++;
        }
        public void DeleteNode(int i)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return;
            }
            if (i < 1 || i > length)
            {
                Console.WriteLine("Position is error!");
                return;
            }
            for (int j = 1; j < length; j++)
            {
                data[j - 1] = data[j];
            }
            length--;
        }
        public T SearchNode(int i)
        {
            if (IsEmpty() || (i < 1) || (i > length))
            {
                Console.WriteLine("List is empty or Position is error!");
                return default(T);
            }
            return data[i - 1];
        }
        public T SearchNode(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return default(T);
            }
            int i = 0;
            for (i = 0; i < length; i++)
            {
                if (data[i].ToString().Contains(value.ToString()))
                {
                    break;
                }
            }
            if (i >= length)
            {
                return default(T);
            }
            return data[i];
        }
        public int GetLength()
        {
            return length;
        }
        public void Clear()
        {
            length = 0;
        }
        public bool IsEmpty()
        {
            if (length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsFull()
        {
            if (length == maxsize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
