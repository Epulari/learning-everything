using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_TowersOfHanoi
{
    public static class HannoiNotUseRecursion
    {
        public static long Pow(int x, int y)
        {
            long sum = 1;
            for (int i = 0; i < y; i++)
            {
                sum *= x;
            }
            return sum;
        }
        public static void Creat(LinkStack<int>[] pillar, int n)
        {
            for (int a = 0; a < 3; a++)
            {
                pillar[a] = new LinkStack<int>();
            }
            pillar[0].Name = 'A';
            //把所有的圆盘按从大到小的顺序放在柱子A上 
            for (int i = 0; i < n; i++)
            {
                pillar[0].Push(n - i);
            }

            //柱子B，C上开始没有没有圆盘 
            for (int i = 0; i < n; i++)
            {
                pillar[1].Push(0);
                pillar[2].Push(0);
            }

            //若n为偶数，按顺时针方向依次摆放 A B C 
            if (n % 2 == 0)
            {
                pillar[1].Name = 'B';
                pillar[2].Name = 'C';
            }
            else    //若n为奇数，按顺时针方向依次摆放 A C B 
            {
                pillar[1].Name = 'C';
                pillar[2].Name = 'B';
            }
        }
        public static void Hannoi(LinkStack<int>[] pillar, long max) //移动汉诺塔的主要函数    
        {
            int k = 0; //累计移动的次数 
            int i = 0;
            int ch;
            while (k < max)
            {
                //按顺时针方向把圆盘1从现在的柱子移动到下一根柱子 
                ch = pillar[i % 3].Pop();
                pillar[(i + 1) % 3].Push(ch);
                Console.WriteLine(string.Format("{0}: Move disk {1} from {2} to {3}", ++k, ch, pillar[i % 3].Name, pillar[(i + 1) % 3].Name));
                i++;
                //把另外两根柱子上可以移动的圆盘移动到新的柱子上 
                if (k < max)
                {                 //把非空柱子上的圆盘移动到空柱子上，当两根柱子都为空时，移动较小的圆盘 
                    if (pillar[(i + 1) % 3].GetTop() == 0 ||
                            pillar[(i - 1) % 3].GetTop() > 0 &&
                            pillar[(i + 1) % 3].GetTop() > pillar[(i - 1) % 3].GetTop())
                    {
                        ch = pillar[(i - 1) % 3].Pop();
                        pillar[(i + 1) % 3].Push(ch);
                        Console.WriteLine(string.Format("{0}: Move disk {1} from {2} to {3}", ++k, ch, pillar[(i - 1) % 3].Name, pillar[(i + 1) % 3].Name));
                    }
                    else
                    {
                        ch = pillar[(i + 1) % 3].Pop();
                        pillar[(i - 1) % 3].Push(ch);
                        Console.WriteLine(string.Format("{0}: Move disk {1} from {2} to {3}", ++k, ch, pillar[(i + 1) % 3].Name, pillar[(i - 1) % 3].Name));
                    }
                }
            }
        }
        interface IStack<T>
        {
            void Push(T item);
            T Pop();
            T GetTop();

            bool IsEmpty();

        }
        public class StackNode<T>
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
        public class LinkStack<T> : IStack<T>
        {
            //存储每根柱子套的上的圆盘情况 

            //柱子的名字，可以是A，B，C中的一个 
            public char Name;
            private StackNode<T> top;
            private int size;
            public StackNode<T> Top
            {
                get { return top; }
                set { top = value; }
            }
            public int Size
            {
                get { return size; }
                set { size = value; }
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
            public T GetTop()
            {
                if (IsEmpty())
                {
                    return default(T);
                }
                return top.Data;
            }
            public T Pop()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack is Empty!");
                    return default(T);
                }
                StackNode<T> p = top;
                top = top.Next;
                --size;
                return p.Data;
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

        static void Main(string[] args)
        {
            //非递归解法 
            int n; //这里的n表示圆盘的个数，
            Console.WriteLine("请输入盘子数：");
            n = Convert.ToInt32(Console.ReadLine());
            LinkStack<int>[] H;
            H = new LinkStack<int>[3];
            HannoiNotUseRecursion.Creat(H, n); //给结构数组设置初值    
            long max = HannoiNotUseRecursion.Pow(2, n) - 1;//动的次数应等于2^n - 1 
            HannoiNotUseRecursion.Hannoi(H, max);//移动汉诺塔的主要函数 
            Console.Read();
        }
    }

}
