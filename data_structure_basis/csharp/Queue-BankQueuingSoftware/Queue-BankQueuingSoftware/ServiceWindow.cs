using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Queue_BankQueuingSoftware
{
    class ServiceWindow
    {
        IBankQueue bankQ;
        public IBankQueue BankQ
        {
            get { return bankQ; }
            set { bankQ = value; }
        }
        public void Service()
        {
            while (true)
            {
                Thread.Sleep(10000);
                if (!bankQ.IsEmpty())
                {
                    Console.WriteLine();
                    lock (bankQ)
                    {
                        Console.WriteLine("请{0}号到{1}号窗口", bankQ.DeQueue(), Thread.CurrentThread.Name);
                    }
                }
            }
        }
    }
}
