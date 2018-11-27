using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedStack_RearrangementOfTrainCarriages
{
    class TrainArrangeByLinkStack
    {
        bool Railroad(int[] p, int n, int k)
        {
            LinkStack<int>[] H;
            H = new LinkStack<int>[k + 1];
            for (int i = 1; i <= k; i++)
                H[i] = new LinkStack<int>();
            int NowOut = 1;
            int minH = n + 1;
            int minS = 0;
            for (int i = 0; i < n; i++)
                if (p[i] == NowOut)
                {
                    Console.WriteLine("Move Car {0} from input to output", p[i]);
                    NowOut++;
                    while (minH == NowOut)
                    {
                        Output(ref minH, ref minS, ref H, k, n);
                        NowOut++;
                    }
                }
                else
                {
                    if (!Hold(p[i], ref minH, ref minS, ref H, k, n))
                        return false;
                }
            return true;
        }
        void Output(ref int minH, ref int minS, ref LinkStack<int>[] H, int k, int n)
        {
            int c;
            c = H[minS].Pop();
            Console.WriteLine("Move Car {0} from holding track {1} to output", minH, minS);
            minH = n + 2;
            for (int i = 1; i <= k; i++)
            {
                if (!H[i].IsEmpty() && (c = H[i].Top.Data) < minH)
                {
                    minH = c;
                    minS = i;
                }
            }
        }
        bool Hold(int c, ref int minH, ref int minS, ref LinkStack<int>[] H, int k, int n)
        {
            int BestTack = 0;
            int BestTop = n + 1;
            int x;
            for (int i = 1; i <= k; i++)
            {
                if (!H[i].IsEmpty())
                {
                    x = H[i].Top.Data;
                    if (c < x && x < BestTop)
                    {
                        BestTop = x;
                        BestTack = i;
                    }
                }
                else
                {
                    if (BestTack == 0) BestTack = i;
                    break;
                }
            }
            if (BestTack == 0) return false;
            H[BestTack].Push(c);
            Console.WriteLine("Move Car {0} from input to holding track {1}", c, BestTack);
            if (c < minH)
            {
                minH = c;
                minS = BestTack;
            }
            return true;
        }
        public static void Main(string[] args)
        {
            int[] p = new int[] { 3, 6, 9, 2, 4, 7, 1, 8, 5 };
            int k = 3;
            TrainArrangeByLinkStack ta = new TrainArrangeByLinkStack();
            bool result;
            result = ta.Railroad(p, p.Length, k);
            do
            {
                if (result == false)
                {
                    Console.Write("need more holding track ,please enter additional number:");
                    k = k + Convert.ToInt32(Console.ReadLine());
                    result = ta.Railroad(p, p.Length, k);
                }
            } while (result == false);
            Console.ReadLine();
        }
        interface IStack<T>
        {
            void Push(T item);
            T Pop();
            T GetTop();
            int GetLength();
            bool IsEmpty();
            void Clear();
        }
        class StackNode<T>
        {
            private T data;
            private StackNode<T> next;
            public StackNode()
            {
                data = default(T);
                next = null;
            }
            public StackNode(T val)
            {
                data = val;
                next = null;
            }
            public StackNode(T val, StackNode<T> p)
            {
                data = val;
                next = p;
            }
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
            public StackNode<T> Next
            {
                get { return next; }
                set { next = value; }
            }
        }
        class LinkStack<T> : IStack<T>
        {
            private int size;
            private StackNode<T> top;
            public int Size
            {
                get { return size; }
                set { size = value; }
            }
            public StackNode<T> Top
            {
                get { return top; }
                set { top = value; }
            }
            public LinkStack()
            {
                top = null;
                size = 0;
            }
            public void Push(T item)
            {
                StackNode<T> q = new StackNode<T>(item);
                if (top == null)
                {
                    top = q;
                }
                else
                {
                    q.Next = top;
                    top = q;
                }
                ++size;
            }
            public T Pop()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack is empty!");
                    return default(T);
                }
                StackNode<T> p = top;
                top = top.Next;
                --size;
                return p.Data;
            }
            public T GetTop()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack is empty!");
                    return default(T);
                }
                return top.Data;
            }
            public int GetLength()
            {
                return size;
            }
            public void Clear()
            {
                top = null;
                size = 0;
            }
            public bool IsEmpty()
            {
                if ((top == null) && (size == 0))
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
}
