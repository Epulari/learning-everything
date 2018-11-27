using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BinaryTree_QuickSearchDisk
{
    class Node<T>
    {
        private T data;//数据域
        private Node<T> lChild;//左孩子
        private Node<T> rChild;//右孩子
        //构造函数
        public Node(T val, Node<T> lp, Node<T> rp)
        {
            data = val;
            lChild = lp;
            rChild = rp;
        }
        public Node(Node<T> lp, Node<T> rp)
        {
            data = default(T);
            lChild = lp;
            rChild = rp;
        }
        public Node(T val)
        {
            data = val;
            lChild = null;
            rChild = null;
        }
        public Node()
        {
            data = default(T);
            lChild =null;
            rChild = null;
        }
        //数据属性
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> LChild
        {
            get { return lChild; }
            set { lChild = value; }
        }
        public Node<T> RChild
        {
            get { return rChild; }
            set { rChild = value; }
        }
    }
    class LinkBiTree<T>
    {
        private Node<T> head;//头引用
        //头引用属性
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }
        //构造函数
        public LinkBiTree()
        {
            head = null;
        }
        public LinkBiTree(T val)
        {
            Node<T> p = new Node<T>(val);
            head = p;
        }
        public LinkBiTree(T val, Node<T> lp, Node<T> rp)
        {
            Node<T> p = new Node<T>(val, lp, rp);
            head = p;
        }
        //判断二叉树是否为空
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //获取根结点
        public Node<T> Root()
        {
            return head;
        }
        //获取结点的左孩子结点
        public Node<T> GetLChild(Node<T> p)
        {
            return p.LChild;
        }
        //获取结点的右孩子结点
        public Node<T> GetRChild(Node<T> p)
        {
            return p.RChild;
        }
        //将结点p的左子树插入值为val的新结点，原来的左子树成为新结点的左子树
        public void InsertL(T val, Node<T> p)
        {
            Node<T> tmp = new Node<T>(val);
            tmp.LChild = p.LChild;
            p.LChild = tmp;
        }
        //将结点p的右子树插入值为val的新结点，原来的右子树成为新结点的右子树
        public void InsertR(T val, Node<T> p)
        {
            Node<T> tmp = new Node<T>(val);
            tmp.RChild = p.RChild;
            p.RChild = tmp;
        }
        //若p非空，删除p的左子树
        public Node<T> DeleteL(Node<T> p)
        {
            if((p==null)||(p.LChild ==null))
            {
                return null;
            }
            Node <T> tmp=p.LChild ;
            p.LChild =null;
            return tmp;
        }
        //若p非空，删除p的右子树
        public Node<T> DeleteR(Node<T> p)
        {
            if((p==null)||(p.RChild ==null))
            {
                return null;
            }
            Node <T> tmp=p.RChild ;
            p.RChild =null;
            return tmp;
        }
        //编写算法，在二叉树中查找值为value的结点
        public Node<T> Search(Node<T> root, T value)
        {
            Node<T> p = root;
            if (p == null)
            {
                return null;
            }
            if (!p.Data.Equals(value))
            {
                return p;
            }
            if (p.LChild != null)
            {
                return Search(p.LChild, value);
            }
            if (p.RChild != null)
            {
                return Search(p.RChild, value);
            }
            return null;
        }
        //判断是否是叶子结点
        public bool IsLeaf(Node<T> p)
        {
            if ((p != null) && (p.LChild == null) && (p.RChild == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //中序遍历
        public void inorder(Node<T> ptr)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is empty!");
                return;
            }
            if (ptr != null)
            {
                inorder(ptr.LChild);
                Console.Write(ptr.Data + " ");
                inorder(ptr.RChild);
            }
        }
        //先序遍历
        public void preorder(Node<T> ptr)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is empty!");
                return;
            }
            if (ptr != null)
            {
                Console.Write(ptr.Data + " ");
                preorder(ptr.LChild);
                preorder(ptr.RChild);
            }
        }
        //后序遍历
        public void postorder(Node<T> ptr)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is empty!");
                return;
            }
            if (ptr != null)
            {
                postorder(ptr.LChild);
                postorder(ptr.RChild);
                Console.Write(ptr.Data + " ");
            }
        }
        //层次遍历
        public void LevelOrder(Node<T> root)
        {
            //根结点为空
            if (root == null)
                return;
            //设置一个队列保存层次遍历的结点
            CSeqQueue<Node<T>> sq = new CSeqQueue<Node<T>>(50);
            //根结点入队
            sq.EnQueue(root);
            //队列非空，结点没有处理完
            while (!sq.IsEmpty())
            {
                Node<T> tmp = sq.DeQueue();
                Console.WriteLine("{0}", tmp);
                if (tmp.LChild != null)
                {
                    //将当前结点的左孩子结点入队
                    sq.EnQueue(tmp.LChild);
                }
                if (tmp.RChild != null)
                {
                    //将当前结点的右孩子结点入队
                    sq.EnQueue(tmp.RChild);
                }
            }
        }

    }
}
