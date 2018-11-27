using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_StudentResult
{
    class DNode<T>
    {
        private T data;
        private DNode<T> prev;
        private DNode<T> next;
        public DNode(T val, DNode<T> p)
        {
            data = val;
            next = p;
        }
        public DNode(DNode<T> p)
        {
            next = p;
        }
        public DNode(T val)
        {
            data = val;
            next = null;
        }
        public DNode()
        {
            data = default(T);
            next = null;
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public DNode<T> Prev
        {
            get { return prev ; }
            set { prev = value; }
        }
        public DNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
    class DLinkList<T>:ILinarList <T>
    {
        private DNode<T> start;
        private int length;
        public DLinkList()
        {
            start = null;
        }
        public void InsertNode(T a)
        {
            DNode <T> newnode=new DNode<T> (a);
            if(IsEmpty())
            {
                start=newnode ;
                length++;
                return ;
            }
            DNode<T> current = start;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newnode;
            newnode.Prev = current;
            newnode.Next = null;
            length++;
        }
        public void InsertNode(T a, int i)
        {
            DNode<T> current;
            DNode<T> previous;
            if (i < 1 )
            {
                Console.WriteLine("Position is error!");
                return;
            }
            DNode<T> newnode = new DNode<T>(a);
            if (i == 1)
            {
                newnode.Next = start;
                start = newnode;
                length++;
                return;
            }
            current = start;
            previous = null;
            int j = 1;
            while (current != null && j < i)
            {
                previous = current;
                current = current.Next;
                j++;
            }
            if (j == i)
            {
                newnode.Next = current;
                newnode.Prev = previous;
                if (current != null)
                    current.Prev = newnode;
                previous.Next = newnode;
                length++;
            }
        }
        public void DeleteNode(int i)
        {
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("Link is enptyor Position is error!");
            }
            DNode<T> current = start;
            if (i == 1)
            {
                start = current.Next;
                length--;
                return;
            }
            DNode<T> previous = null;
            int j = 1;
            while (current.Next != null && j < i)
            {
                previous = current;
                current = current.Next;
                j++;
            }
            if (j == i)
            {
                previous.Next = current.Next;
                if (current.Next != null)
                    current.Next.Prev = previous;
                previous = null;
                current = null;
                length--;
            }
            else
            {
                Console.WriteLine("The ith node is not exist!");
            }
        }
        public T SearchNode(int i)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return default(T);
            }
            DNode<T> current = start;
            int j = 1;
            while (current.Next != null && j < i)
            {
                current = current.Next;
                j++;
            }
            if (j == i)
            {
                return current.Data;
            }
            else
            {
                Console.WriteLine("The ith node is not exist!");
                return default(T);
            }
        }
        public T SearchNode(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return default(T);
            }
            DNode<T> current = start;
            int i = 1;
            while (!current.Data.ToString().Contains(value.ToString()) && current != null)
            {
                current = current.Next;
                i++;
            }
            if (current != null)
            {
                return current.Data;
            }
            else
            {
                return default(T);
            }
        }
        public int GetLength()
        {
            return length;
        }
        public void Clear()
        {
            start = null;
        }
        public bool IsEmpty()
        {
            if (start == null)
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
