using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree_QuickSearchDisk
{
    class Program
    {
        public struct indexnode
        {
            int key;
            int offset;
            public indexnode(int key, int offset)
            {
                this.key = key;
                this.offset = offset;
            }
            //键属性
            public int Key
            {
                get { return key; }
                set { value = key; }
            }
            //位置属性
            public int Offset
            {
                get { return offset; }
                set { value = offset; }
            }
        }
        //定义二叉搜索树
        public class LinkBiSearchTree : LinkBiTree<indexnode>
        {
            //定义增加结点的方法
            public void insert(indexnode element)
            {
                Node<indexnode> tmp, parent = null, currentNode = null;
                //调用find方法
                find(element, ref parent, ref currentNode);
                if (currentNode != null)
                {
                    Console.WriteLine("Duplicates words not allowed");
                    return;
                }
                else
                {
                    //创建结点
                    tmp = new Node<indexnode>(element);
                    if (parent == null)
                        Head = tmp;
                    else
                        if (element.Key < parent.Data.Key)
                        parent.LChild = tmp;
                    else
                        parent.RChild = tmp;
                }
            }
            //定位父节点
            public void find(indexnode element, ref Node<indexnode> parent, ref Node<indexnode> currentNode)
            {
                currentNode = Head;
                parent = null;
                while ((currentNode != null) && (currentNode.Data.ToString() != element.ToString()))
                {
                    parent = currentNode;
                    if (element.Key < currentNode.Data.Key)
                        currentNode = currentNode.LChild;
                    else
                        currentNode = currentNode.RChild;
                }
            }
            //定位结点
            public void find(int key)
            {
                Node<indexnode> currentNode = Head;
                while ((currentNode != null) && (currentNode.Data.Key != key))
                {
                    Console.WriteLine(currentNode.Data.Key);
                    if (key < currentNode.Data.Key)
                        currentNode = currentNode.LChild;
                    else
                        currentNode = currentNode.RChild;
                }
            }
            static void Main(string[] args)
            {
                LinkBiSearchTree b = new LinkBiSearchTree();
                while (true)
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1.创建二叉搜索树");
                    Console.WriteLine("2.执行中序遍历");
                    Console.WriteLine("3.执行先序遍历");
                    Console.WriteLine("4.执行后序遍历");
                    Console.WriteLine("5.显示搜索一个结点的路径");
                    Console.WriteLine("6.exit");
                    Console.Write("\n输入你的选择（1-5）：");
                    char ch = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine();
                    switch (ch)
                    {
                        case '1':
                            {
                                int key, offset;
                                string flag;
                                do
                                {
                                    Console.Write("请输入键：");
                                    key = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("请输入位置：");
                                    offset = Convert.ToInt32(Console.ReadLine());
                                    indexnode elem = new indexnode(key, offset);
                                    b.insert(elem);
                                    Console.Write("继续添加新的结点吗（Y/N）：");
                                    flag = Console.ReadLine();
                                } while (flag == "Y" || flag == "y");
                            }
                            break;
                        case '2':
                            {
                                b.inorder(b.Head);
                            }
                            break;
                        case '3':
                            {
                                b.preorder(b.Head);
                            }
                            break;
                        case '4':
                            {
                                b.postorder(b.Head);
                            }
                            break;
                        case '5':
                            {
                                int key;
                                Console.Write("请输入键：");
                                key = Convert.ToInt32(Console.ReadLine());
                                b.find(key);
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
            }
        }
    }
}
