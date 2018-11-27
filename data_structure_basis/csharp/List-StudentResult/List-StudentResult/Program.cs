using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_StudentResult
{
    class StuNode
    {
        private string stu_no;
        private string stu_name;
        private int stu_score;
        public string Stu_no
        {
            get { return stu_no; }
            set { stu_no = value; }
        }
        public string Stu_name
        {
            get { return stu_name; }
            set { stu_name = value; }
        }
        public int Stu_score
        {
            get { return stu_score; }
            set { stu_score = value; }
        }
        public StuNode(string stu_no, string stu_name, int stu_score)
        {
            this.stu_no = stu_no;
            this.stu_name = stu_name;
            this.stu_score = stu_score;
        }
        public override string ToString()
        {
            return stu_no + Stu_name;
        }
    }
    class SeqListApp
    {
        public static void Main(string[] args)
        {
            ILinarList<StuNode> stuList = null;
            Console.Write("请输入学生人数：");
            int maxsize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请选择存储结构类型：1.顺序表 2.单链表 3.双链表 4.循环链表");
            char seleflag = Convert.ToChar(Console.ReadLine());
            switch (seleflag)
            {
                case '1':
                    stuList = new SeqList<StuNode>(maxsize);
                    break;
                case '2':
                    stuList = new SLinkList<StuNode>();
                    break;
                case '3':
                    stuList = new DLinkList<StuNode>();
                    break;
            }
            while (true)
            {
                Console.WriteLine("请输入操作选项：");
                Console.WriteLine("1.添加学生成绩");
                Console.WriteLine("2.删除学生成绩");
                Console.WriteLine("3.按姓名查询学生成绩");
                Console.WriteLine("4.按学号查询学生成绩");
                Console.WriteLine("5.按升序显示所有的学生成绩");
                Console.WriteLine("6.按降序显示所有的学生成绩");
                Console.WriteLine("7.退出");
                seleflag = Convert.ToChar(Console.ReadLine());
                switch (seleflag)
                {
                    case '1':
                        {
                            char flag;
                            do
                            {
                                string stu_no;
                                string stu_name;
                                int stu_score;
                                Console.Write("请输入学号：");
                                stu_no = Console.ReadLine();
                                Console.Write("请输入姓名：");
                                stu_name = Console.ReadLine();
                                Console.Write("请输入学生成绩：");
                                stu_score = Convert.ToInt32(Console.ReadLine());
                                StuNode newNode = new StuNode(stu_no, stu_name, stu_score);
                                if (stuList.GetLength() == 0)
                                {
                                    stuList.InsertNode(newNode, 1);
                                }
                                else if (newNode.Stu_score > (stuList.SearchNode(stuList.GetLength()).Stu_score))
                                {
                                    stuList.InsertNode(newNode, stuList.GetLength() + 1);
                                }
                                else
                                {
                                    for (int i = 1; i < stuList.GetLength(); i++)
                                    {
                                        if (newNode.Stu_score <= (stuList.SearchNode(i).Stu_score))
                                        {
                                            stuList.InsertNode(newNode, i);
                                            break;
                                        }
                                    }
                                }
                                Console.Write("还有学生成绩输入吗（Y/N）：");
                                flag = Convert.ToChar(Console.ReadLine());
                            } while (flag == 'Y');
                            break;
                        }
                    case '2':
                        {
                            StuNode temp;
                            Console.Write("请输入要删除学生的学号：");
                            string stu_no = Console.ReadLine();
                            for (int i = 1; i <= stuList.GetLength(); i++)
                            {
                                temp = stuList.SearchNode(i);
                                if (temp.Stu_no == stu_no)
                                {
                                    stuList.DeleteNode(i);
                                    break;
                                }
                            }
                            break;
                        }
                    case '3':
                        {
                            StuNode temp;
                            Console.Write("请输入要查询的学生姓名：");
                            string stu_name = Console.ReadLine();
                            for (int i = 1; i <= stuList.GetLength(); i++)
                            {
                                temp = stuList.SearchNode(i);
                                if (temp.Stu_name == stu_name)
                                {
                                    Console.WriteLine("{0}的成绩是：{1}", stu_name, temp.Stu_score);
                                    break;
                                }
                            }
                            break;
                        }
                    case '4':
                        {
                            StuNode temp;
                            Console.Write("请输入要查询的学生学号：");
                            string stu_no = Console.ReadLine();
                            for (int i = 1; i <= stuList.GetLength(); i++)
                            {
                                temp = stuList.SearchNode(i);
                                if (temp.Stu_no == stu_no)
                                {
                                    Console.WriteLine("学号为{0}的成绩是：{1}", stu_no, temp.Stu_score);
                                    break;
                                }
                            }
                            break;
                        }
                    case '5':
                        {
                            StuNode temp = null;
                            for (int i = 1; i < stuList.GetLength(); i++)
                            {
                                temp = stuList.SearchNode(i);
                                Console.WriteLine("t{0}\t{1}\t{2}", temp.Stu_no, temp.Stu_name, temp.Stu_score);
                            }
                            break;
                        }
                    case '6':
                        {
                            StuNode temp = null;
                            for (int i = stuList.GetLength(); i >= 1; i--)
                            {
                                temp = stuList.SearchNode(i);
                                Console.WriteLine("t{0}\t{1}\t{2}", temp.Stu_no, temp.Stu_name, temp.Stu_score);
                            }
                            break;
                        }
                    case '7':
                        {
                            return;
                        }
                }
                Console.Write("按任意键继续……");
                Console.ReadLine();
            }
        }
    }
}