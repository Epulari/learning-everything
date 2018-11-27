using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStack_RearrangementOfTrainCarriages
{
    class TrainArrangeBySeqStack
    {
        bool Railroad(int[] p, int n, int k)
        {
            SeqStack<int>[] H;
            H = new SeqStack<int>[k + 1];
            for (int i = 1; i <= k; i++)
                H[i] = new SeqStack<int>(p.Length);
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
        void Output(ref int minH, ref int minS, ref SeqStack<int>[] H, int k, int n)
        {
            int c;
            c = H[minS].Pop();
            Console.WriteLine("Move Car {0} from holding trak {1} to output", minH, minS);
            minH = n + 2;
            for (int i = 1; i <= k; i++)
                if (!H[i].IsEmpty() && (H[i].GetTop()) < minH)
                {
                    minH = c;
                    minS = i;
                }
        }
        bool Hold(int c, ref int minH, ref int minS, ref SeqStack<int>[] H, int k, int n)
        {
            int BestTrack = 0;
            int BestTop = n + 1;
            int x;
            for (int i = 1; i <= k; i++)
            {
                if (!H[i].IsEmpty())
                {
                    x = H[i].GetTop();
                    if (c < x && x < BestTop)
                    {
                        BestTop = x;
                        BestTrack = i;
                    }
                }
                else
                {
                    if (BestTrack == 0)
                        BestTrack = i;
                    break;
                }
            }
            if (BestTrack == 0)
                return false;
            H[BestTrack].Push(c);
            Console.WriteLine("Move Car {0} from input to holding track {1}", c, BestTrack);
            if (c < minH)
            {
                minH = c;
                minS = BestTrack;
            }
            return true;
        }

        public static void Main(string[] args)
        {
            int[] p = new int[] { 3, 6, 9, 2, 4, 7, 1, 8, 5 };
            int k = 3;
            TrainArrangeBySeqStack ta = new TrainArrangeBySeqStack();
            bool result;
            result = ta.Railroad(p, p.Length, k);
            do
            {
                if (result == false)
                {
                    Console.Write("need more holding track,please enter additional number:");
                    k = k + Convert.ToInt32(Console.ReadLine());
                    result = ta.Railroad(p, p.Length, k);
                }
            } while (result == false);
            Console.ReadLine();
        }
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
    class SeqStack<T> : IStack<T>
    {
        private int maxsize;
        private T[] data;
        private int top;
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
        public int Top
        {
            get { return top; }
        }
        public SeqStack(int size)
        {
            data = new T[size];
            maxsize = size;
            top = -1;
        }
        public void Push(T elem)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is full!");
                return;
            }
            data[++top] = elem;
        }
        public T Pop()
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return tmp;
            }
            tmp = data[top];
            --top;
            return tmp;
        }
        public T GetTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            return data[top];
        }
        public int GetLength()
        {
            return top + 1;
        }
        public void Clear()
        {
            top = -1;
        }
        public bool IsEmpty()
        {
            if (top == -1)
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
            if (top == maxsize - 1)
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

