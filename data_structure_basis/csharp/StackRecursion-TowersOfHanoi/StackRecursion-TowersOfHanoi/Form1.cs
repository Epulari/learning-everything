using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO;
using System.EnterpriseServices;

namespace StackRecursion_TowersOfHanoi
{
    public partial class Form1 : Form
    {
        MyStack SK1 = new MyStack();
        MyStack SK2 = new MyStack();
        MyStack SK3 = new MyStack();
        int num = 4;
        int time = 1000;
        public Form1()
        {
            InitializeComponent();
            for (int value = 1; value <= num; value++)
            {
                SK1.Push(value);
            }
            this.Refresh();
            textBox1.Text = "1000";

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //初始化画图设备
            Graphics dc = e.Graphics;
            //制作一个笔
            Pen bluepen = new Pen(Color.Blue, 3);
            Pen redpen = new Pen(Color.Red, 3);
            //画直线
            for (int i = 1; i <= 3; i++)
            {
                dc.DrawLine(bluepen, i * 210 - 160, 200, 210 * i, 200);//绘制横线
                dc.DrawLine(bluepen, 210 * (i - 1) + 130, 50, 210 * (i - 1) + 130, 200);//绘制竖线                
            }
            //画矩形
            if (!SK1.IsEmpty())
            {
                SK1.MoveHaid();
                for (int ia = 1; ia <= SK1.GetLength(); ia++)
                {
                    int m = SK1.GetCurrentValue();
                    SK1.NextStack();
                    dc.DrawRectangle(redpen, 60 + 10 * m, 200 - 15 * ia, 120 - (m - 1) * 20, 15);
                }
            }
            if (!SK2.IsEmpty())
            {
                SK2.MoveHaid();
                for (int ib = 1; ib <= SK2.GetLength(); ib++)
                {
                    int m = SK2.GetCurrentValue();
                    SK2.NextStack();
                    dc.DrawRectangle(redpen, 270 + 10 * m, 200 - 15 * ib, 120 - (m - 1) * 20, 15);
                }
            }
            if (!SK3.IsEmpty())
            {
                SK3.MoveHaid();
                for (int ic = 1; ic <= SK3.GetLength(); ic++)
                {
                    int m = SK3.GetCurrentValue();
                    SK3.NextStack();
                    dc.DrawRectangle(redpen, 480 + 10 * m, 200 - 15 * ic, 120 - (m - 1) * 20, 15);
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button4.Enabled = true;
            try
            {
                time = int.Parse(textBox1.Text);
            }
            catch (Exception)
            {

            }

            HNT(num, SK1, SK2, SK3);

        }
        public void HNT(int i, MyStack a, MyStack b, MyStack c)
        {
            if (i > 0)
            {
                HNT(i - 1, a, c, b);
                c.Push(a.Top());
                a.Pop();
                Thread.Sleep(time);
                Graphics f = CreateGraphics();
                Rectangle Rct = new Rectangle(0, 0, -200, -20);
                OnPaint(new PaintEventArgs(f, Rct));
                this.Refresh();
                HNT(i - 1, b, a, c);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (num == 7)
            {
                MessageBox.Show("不能再添加了！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            num += 1;
            SK1.Push(num);
            this.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (num == 1)
            {
                MessageBox.Show("不能再删除了！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                num -= 1;
                SK1.Pop();
                this.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button1.Enabled = true;
            SK1.ClearStack();
            SK2.ClearStack();
            SK3.ClearStack();
            for (int i = 1; i <= num; i++)
            {
                SK1.Push(i);
            }
            this.Refresh();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}