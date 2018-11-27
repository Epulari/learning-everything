using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Queue_BankQueuingSoftware
{
    class BankQueueApp
    {
        public static void Main(string[] args)
        {
            IBankQueue bankQueue = null;
            Console.WriteLine("请选择存储结构的类型：1.顺序队列 2.链队列");
            char seleflag = Convert.ToChar(Console.ReadLine());
            switch (seleflag)
            {
                case '1':
                    int count;
                    Console.Write("请输入队列可容纳人数：");
                    count = Convert.ToInt32(Console.ReadLine());
                    bankQueue = new CSeqBankQueue(count);
                    break;
                case '2':
                    bankQueue = new LinkBankQueue();
                    break;
            }
            int windowcount = 1;
            ServiceWindow[] sw = new ServiceWindow[windowcount];
            Thread[] swt = new Thread[windowcount];
            for (int i = 0; i < windowcount; i++)
            {
                sw[i] = new ServiceWindow();
                sw[i].BankQ = bankQueue;
                swt[i] = new Thread(new ThreadStart(sw[i].Service));
                swt[i].Name = "" + (i + 1);
                swt[i].Start();
            }
            while (true)
            {
                Console.Write("请点击触摸屏幕获取号码：");
                Console.ReadLine();
                int callnumber;
                if (!bankQueue.IsFull())
                {
                    callnumber = bankQueue.GetCallnumber();
                    Console.WriteLine("您的号码是：{0}，你前面有{1}位，请等待", callnumber, bankQueue.GetLength());
                    bankQueue.EnQueue(callnumber);
                }
                else
                    Console.WriteLine("现在业务繁忙，请稍后再来！");
                Console.WriteLine();
            }
        }
    }
}
