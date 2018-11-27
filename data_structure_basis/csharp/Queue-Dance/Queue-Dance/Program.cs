using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Queue_Dance
{

    class Program
    {
        class Ball
        {
            IBallQueue mballQ;
            IBallQueue fballQ;
            IBallQueue lun;
            public IBallQueue MballQ
            {
                get
                {
                    return mballQ;
                }
                set
                {
                    mballQ = value;
                }
            }
            public IBallQueue FballQ
            {
                get
                {
                    return fballQ;
                }
                set
                {
                    fballQ = value;
                }
            }
            public IBallQueue Lun
            {
                get
                {
                    return lun;
                }
                set
                {
                    lun = value;
                }
            }
            public void Dance()
            {

                int a = 0, b = 0, m = 0, n = 0, p = 0, q = 1;
                int[] c = new int[100];
                int[] d = new int[100];
                string[] C = new string[100];
                string[] D = new string[100];
                string[] H = new string[200];
                while (true)
                {
                    Thread.Sleep(6000);

                    if (!mballQ.IsEmpty() && !fballQ.IsEmpty())
                    {
                        c[a] = fballQ.GetFront();//获取女嘉宾的头结点数值，存入数组c中
                        d[b] = mballQ.GetFront();
                        C[a] = c[a].ToString();//将int型数组的数值转换为string型数值
                        D[b] = d[b].ToString();
                        Console.WriteLine("请女嘉宾{0}号与男嘉宾{1}号进入舞会！", fballQ.DeQueue(), mballQ.DeQueue());//一对一对出队，跳舞
                        H[p] = C[a] + D[b];//数组H存储男女嘉宾跳舞的组合
                        a++; b++;
                        p++;
                    }
                    else
                    {
                        Thread.Sleep(4000);
                        Console.WriteLine("第{0}场舞会结束", q);
                        ++q;
                        Console.WriteLine("        ******        ");//间隔
                        if (q > lun.GetLength())//判断跳舞的场数，当q与歌曲数目相等时结束舞会
                        {
                            Console.WriteLine("本周末舞会全部结束，感谢各位参与！以下是今晚共舞过的舞友：");
                            for (int i = 0; i < a; i++)
                            {
                                for (int j = 0; j < b; j++)
                                {
                                    if (H[i] == H[j] && i != j)//相同的跳舞组合则不再显示
                                    {
                                        break;
                                    }
                                    if (i == j)
                                    {
                                        Console.WriteLine("女嘉宾{0}号与男嘉宾{1}号", C[i], D[j]);
                                    }
                                }
                            }
                            Console.ReadKey();
                            break;
                        }
                        while (m < a)//女嘉宾重新进入队列
                        {
                            fballQ.EnQueue(c[m]);
                            m++;
                        }
                        while (n < b)
                        {
                            mballQ.EnQueue(d[n]);
                            n++;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //定义三个队列：男嘉宾、女嘉宾、跳舞轮数（歌曲数目）
            IBallQueue mballQueue = null;
            IBallQueue fballQueue = null;
            IBallQueue lun = null;

            //实例化三个队列
            mballQueue = new LinkBallQueue();
            fballQueue = new LinkBallQueue();
            lun = new LinkBallQueue();

            Ball[] ball = new Ball[1];
            Thread[] thread = new Thread[1];
            ball[0] = new Ball();
            ball[0].MballQ = mballQueue;
            ball[0].FballQ = fballQueue;
            ball[0].Lun = lun;

            //次线程指向Ball类里的Dance()方法（即执行Dance()方法）
            thread[0] = new Thread((new ThreadStart(ball[0].Dance)));
            thread[0].Start();//启用线程
            while (true)
            {
                Console.WriteLine("请输入女舞者人数：");
                string fballnumber = Console.ReadLine();
                for (int i = 1; i <= Convert.ToInt32(fballnumber); i++)//女嘉宾进队列
                {
                    i = fballQueue.GetBallnumber();
                    fballQueue.EnQueue(i);
                }
                Console.WriteLine("请输入男舞者人数：");
                string mballnumber = Console.ReadLine();
                for (int i = 1; i <= Convert.ToInt32(mballnumber); i++)//男嘉宾进队列
                {
                    i = mballQueue.GetBallnumber();
                    mballQueue.EnQueue(i);
                }
                Console.WriteLine("请输入歌曲数目：");
                string lunnumber = Console.ReadLine();
                for (int i = 1; i <= Convert.ToInt32(lunnumber); i++)//歌曲数目进队列（队列的长度为歌曲数目）
                {
                    i = lun.GetBallnumber();
                    lun.EnQueue(i);
                }

                break;
            }
        }
        interface IQueue<T>
        {
            void EnQueue(T elem);
            T DeQueue();
            T GetFront();
            int GetLength();
            bool IsEmpty();
            void Clear();
        }
        class QueueNode<T>
        {
            private T data;
            private QueueNode<T> next;
            public QueueNode(T val, QueueNode<T> p)
            {
                data = val;
                next = p;
            }
            public QueueNode(QueueNode<T> p)
            {
                next = p;
            }
            public QueueNode(T val)
            {
                data = val;
                next = null;
            }
            public QueueNode()
            {
                data = default(T);
                next = null;
            }
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
            public QueueNode<T> Next
            {
                get { return next; }
                set { next = value; }
            }
        }
        class LinkQueue<T> : IQueue<T>
        {
            private QueueNode<T> front;
            private QueueNode<T> rear;
            private int size;
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
            public int Size
            {
                get { return size; }
                set { size = value; }
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
                {
                    rear = null;
                }
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
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        interface IBallQueue : IQueue<int>
        {
            int GetBallnumber();
        }
        class LinkBallQueue : LinkQueue<int>, IBallQueue
        {
            private int ballnumber;
            public int Ballnumber
            {
                get
                {
                    return ballnumber;
                }
                set
                {
                    ballnumber = value;
                }
            }
            public int GetBallnumber()
            {
                if ((IsEmpty()) && ballnumber == 0)
                {
                    ballnumber = 1;
                }
                else
                {
                    ballnumber++;
                }
                return ballnumber;
            }
        }

    }

}
