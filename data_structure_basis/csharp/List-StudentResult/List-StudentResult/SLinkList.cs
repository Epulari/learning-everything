using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_StudentResult
{
    class SNode<T>
    {
        private T data;
        private SNode<T> next;
        public SNode(T val, SNode<T> p)
        {
            data = val;
            next = p;
        }
        public SNode(SNode<T> p)
        {
            next = p;
        }
        public SNode(T val)
        {
            data = val;
            next = null;
        }
        public SNode()
        {
            data = default(T);
            next = null;
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public SNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
    class SLinkList<T>:ILinarList <T>
    {
        private SNode<T> start;
        int length;
        public SLinkList()
        {
            start = null;
        }
        public void InsertNode(T a)
        {
            if (start == null)
            {
                start = new SNode<T>(a);
                length++;
                return;
            }
            SNode<T> current = start;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new SNode<T>(a);
            length++;
        }
        public void InsertNode(T a, int i)
        {
            SNode<T> current;
            SNode<T> previous;
            if (i < 1 || i > length + 1)
            {
                Console.WriteLine("Position is error!");
                return;
            }
            SNode<T> newnode = new SNode<T>(a);
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
                previous.Next = newnode;
                newnode.Next = current;
                length++;
            }
        }
        public void DeleteNode(int i)
        {
            if(IsEmpty()||i<1)
            {
                Console .WriteLine ("Link is enptyor Position is error!");
            }
            SNode <T> current=start ;
            if(i==1)
            {
                start =current.Next;
                length--;
                return ;
            }
            SNode <T> previous=null;
            int j=1;
            while(current.Next!=null&&j<i)
            {
                previous =current ;
                current =current .Next ;
                j++;
            }
            if(j==i)
            {
                previous .Next =current .Next ;
                current =null;
                length --;
            }
            else
            {
                Console .WriteLine ("The ith node is not exist!");
            }
        }
        public T SearchNode(int i)
        {
            if(IsEmpty())
            {
                Console .WriteLine ("List is empty!");
                return default (T);
            }
            SNode <T> current=start;
            int j=1;
            while (current .Next !=null&&j<i)
            {
                current =current .Next ;
                j++;
            }
            if(j==i)
            {
                return current .Data;
            }
            else 
            {
                Console .WriteLine ("The ith node is not exist!");
                return default (T);
            }
        }
        public T SearchNode(T value)
        {
            if(IsEmpty())
            {
                Console .WriteLine ("List is empty!");
                return default (T);
            }
            SNode <T> current=start ;
            int i=1;
            while (!current .Data .ToString ().Contains (value.ToString ())&&current !=null)
            {
                current =current .Next;
                i++;
            }
            if(current !=null)
            {
                return current .Data ;
            }
            else 
            {
                return default (T);
            }
        }
        public int GetLength()
        {
            return length ;
        }
        public void Clear()
        {
            start =null;
        }
        public bool IsEmpty()
        {
            if(start ==null)
            {
                return true ;
            }
            else 
            {
                return false ;
            }
        }
    }
}
    

