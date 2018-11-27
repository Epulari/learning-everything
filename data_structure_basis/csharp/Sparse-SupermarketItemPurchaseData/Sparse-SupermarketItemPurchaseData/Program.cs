using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparse_SupermarketItemPurchaseData
{
    class spmaxtrixApp
    {
        public static void Main(string[] args)
        {
            spmatrix<int> M = null;
            int i, j, v;
            int[] price = new int[] { 20, 35, 10, 2, 98, 22 };
            while (true)
            {
                Console.WriteLine("请输入操作选项：");
                Console.WriteLine("1.初始化产品购买数据矩阵");
                Console.WriteLine("2.显示产品购买数据矩阵");
                Console.WriteLine("3.显示产品购买数据矩阵的转置矩阵");
                Console.WriteLine("4.显示每位顾客的销售金额");
                Console.WriteLine("5.退出");
                char seleflag = Convert.ToChar(Console.ReadLine());
                switch (seleflag)
                {
                    case '1':
                        {
                            char flag;
                            int max, pronum, cusnum;
                            Console.Write("请输入产品数：");
                            pronum = Convert.ToInt32(Console.ReadLine());
                            Console.Write("请输入顾客数：");
                            cusnum = Convert.ToInt32(Console.ReadLine());
                            Console.Write("请输入最大非零数：");
                            max = Convert.ToInt32(Console.ReadLine());
                            M = new spmatrix<int>(max, pronum, cusnum);
                            int z = 0;
                            do
                            {
                                Console.WriteLine("请依次输入第{0}个三元组的产品号、客户号、购买数量：", (z + 1));
                                i = Convert.ToInt32(Console.ReadLine());
                                j = Convert.ToInt32(Console.ReadLine());
                                v = Convert.ToInt32(Console.ReadLine());
                                M.setData(i, j, v);
                                Console.Write("还有数据输入吗（Y/N）：");
                                flag = Convert.ToChar(Console.ReadLine());
                                z++;
                            } while (flag == 'Y' && z <= max);
                            break;
                        }
                    case '2':
                        {
                            int z = 0;
                            Console.WriteLine("以产品编号为行，客户编号为列的矩阵是：");
                            for (int row = 0; row < M.Md; row++)
                            {
                                for (int col = 0; col < M.Md; col++)
                                {
                                    for (z = 0; z < M.Td; z++)
                                    {
                                        if (M.Data[z].i == row && M.Data[z].j == col)
                                        {
                                            Console.Write("{0}\t", M.Data[z].v);
                                            break;
                                        }
                                    }
                                    if (z == M.Td)
                                        Console.WriteLine("0\t");
                                }
                                Console.WriteLine();
                            }
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("以客户编号为行，产品编号为列的矩阵是：");
                            spmatrix<int> N = new spmatrix<int>();
                            N = M.Transpose();
                            int z = 0;
                            for (int row = 0; row < N.Md; row++)
                            {
                                for (int col = 0; col < N.Nd; col++)
                                {
                                    for (z = 0; z < N.Td; z++)
                                    {
                                        if (N.Data[z].i == row && N.Data[z].j == col)
                                        {
                                            Console.Write("{0}\t", N.Data[z].v);
                                            break;
                                        }
                                    }
                                    if (z == N.Td)
                                        Console.Write("0\t");
                                }
                                Console.WriteLine();
                            }
                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("顾客的销售金额清单如下：");
                            Console.WriteLine("编号\t 金额");
                            int sum = 0;
                            for (int q = 0; q < M.Nd; q++)
                            {
                                for (int p = 0; p < M.Td; p++)
                                {
                                    if (M.Data[p].j == q)
                                    {
                                        sum = sum + M.Data[p].v * price[M.Data[p].i];
                                    }
                                }
                                Console.WriteLine("{0}\t{1}", q, sum);
                                sum = 0;
                            }
                            break;
                        }
                    case '5':
                        {
                            return;
                        }
                }
                Console.Write("按任意键继续……");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
    struct tupletype<T>
    {
        public int i;
        public int j;
        public T v;
        public tupletype(int i, int j, T v)
        {
            this.i = i;
            this.j = j;
            this.v = v;
        }
    }
    class spmatrix<T>
    {
        int MAXNUM;
        int md;
        int nd;
        int td;
        tupletype<T>[] data;
        public int Md
        {
            get { return md; }
            set { md = value; }
        }
        public int Nd
        {
            get { return nd; }
            set { nd = value; }
        }
        public int Td
        {
            get { return td; }
            set { td = value; }
        }
        public tupletype<T>[] Data
        {
            get { return data; }
            set { data = value; }
        }
        public spmatrix() { }
        public spmatrix(int maxnum, int md, int nd)
        {
            this.MAXNUM = maxnum;
            this.md = md;
            this.nd = nd;
            data = new tupletype<T>[MAXNUM];
        }
        public void setData(int i, int j, T v)
        {
            data[td] = new tupletype<T>(i, j, v);
            td++;
        }
        public spmatrix<T> Transpose()
        {
            spmatrix<T> N = new spmatrix<T>();
            int p, q, col;
            N.MAXNUM = MAXNUM;
            N.nd = md;
            N.md = nd;
            N.td = td;
            N.data = new tupletype<T>[N.td];
            if (td != 0)
            {
                q = 0;
                for (col = 0; col < nd; col++)
                {
                    for (p = 0; p < td; p++)
                    {
                        if (data[p].j == col)
                        {
                            N.data[q].i = data[p].j;
                            N.data[q].j = data[p].i;
                            N.data[q].v = data[p].v;
                            q++;
                        }
                    }
                }
            }
            return N;
        }
    }
}
