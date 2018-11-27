using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List_JosephPermutation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICircleList<Ciphertext_index> LoopPassWordList = null;
            LoopPassWordList = new CircleLinkList<Ciphertext_index>();
            char[] Cipher_Text = textBox1.Text.ToArray();
            int Length = textBox1.Text.Length;
            Ciphertext_index[] PW = new Ciphertext_index[Length];
            char[] temp = new char[Length];
            int key = Convert.ToInt32(textBox2.Text);
            if (Length != 0)
            {
                int index = 0;
                int i = 0;
                for (; i < Length; i++)
                {
                    index++;
                    Ciphertext_index newnode = new Ciphertext_index(index, Cipher_Text[i]);
                    LoopPassWordList.AppendNode(newnode);
                }
                PW = LoopPassWordList.DeleteNode_Encrypt(key);
                for (int m = 0; m < Length; m++)
                {
                    PW[m].Ciphertext = Cipher_Text[m];
                }
                for (int n = 0; n < Length; n++)
                {
                    int s = 0;
                    while (s < Length)
                    {
                        if (PW[s].Index == (n + 1))
                            temp[n] = PW[s].Ciphertext;
                        s++;
                    }
                }
                textBox3.Text = new string(temp);
            }
        }
        class CircleLinkNode<T>
        {
            private T data;
            private CircleLinkNode<T> next;
            public CircleLinkNode(T val, CircleLinkNode<T> p)
            {
                data = val;
                next = p;
            }
            public CircleLinkNode(T val)
            {
                data = val;
            }
            public CircleLinkNode(CircleLinkNode<T> p)
            {
                next = p;
            }
            public CircleLinkNode()
            {
                data = default(T);
                next = null;
            }
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
            public CircleLinkNode<T> Next
            {
                get { return next; }
                set { next = value; }
            }
        }
        class CircleLinkList<T> : ICircleList<T>
        {
            private CircleLinkNode<T> head;
            private int length;
            public CircleLinkNode<T> Head
            {
                get
                { return head; }
                set
                {
                    head = value;
                }
            }
            public CircleLinkList()
            {
                this.head = null;
            }
            public void AppendNode(T a)
            {

                if (head == null)
                {
                    head = new CircleLinkNode<T>(a);
                    head.Next = head;
                    length++;
                    return;
                }
                CircleLinkNode<T> current = head;
                CircleLinkNode<T> newnode = new CircleLinkNode<T>(a);
                for (int i = 0; i < length - 1; i++)
                    current = current.Next;
                current.Next = newnode;
                newnode.Next = this.Head;
                length++;
            }
            public T[] DeleteNode_Encrypt(int key)
            {
                CircleLinkNode<T> current1 = head;
                CircleLinkNode<T> current2 = head;
                T[] Data = new T[length];
                for (int i = 0; i < length; i++)
                {
                    for (int j = 1; j < key; j++)
                    {
                        current1 = current2;
                        current2 = current2.Next;
                    }
                    current1.Next = current2.Next;
                    Data[i] = current2.Data;
                    current2 = current1.Next;
                }
                return Data;
            }
            public bool IsEmpty()
            {
                if (head == null)
                {
                    return true;
                }
                else { }
                return false;
            }
        }
        class Ciphertext_index
        {
            private char ciphertext;
            private int index;
            public char Ciphertext
            {
                get { return ciphertext; }
                set { ciphertext = value; }
            }
            public int Index
            {
                get { return index; }
                set { index = value; }
            }
            public Ciphertext_index(int index, char ciphertext)
            {
                this.ciphertext = ciphertext;
                this.index = index;
            }
        }
        interface ICircleList<T>
        {
            void AppendNode(T a);
            T[] DeleteNode_Encrypt(int key);
            bool IsEmpty();
        }
    }
}
