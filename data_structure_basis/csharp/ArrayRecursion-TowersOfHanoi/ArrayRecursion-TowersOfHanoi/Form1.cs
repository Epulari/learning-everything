using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ArrayRecursion_TowersOfHanoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int i; //移动的次数
        public PictureBox[] Plate = new PictureBox[11];
        const int PlateHeight = 17; //盘片厚度
        private bool isDragging = false;
        private int x1, y1;
        private ArrayList A = new ArrayList();
        private ArrayList B = new ArrayList();
        private ArrayList C = new ArrayList();
        //ArrayList 就是数组列表，它位于System.Collections名称空间下，是集合类型。 
        private int oldx, oldy;
        private void load_plate(int n)
        {
            //加载盘片 
            //盘片编号从上往下1,2,...n 
            for (i = 1; i <= n; i++)
            {
                Plate[i] = new PictureBox();
                this.Controls.Add(Plate[i]);
                Plate[i].Left = 48 + (n - i) * 5;
                Plate[i].Top = 167 - (n - i + 1) * PlateHeight;
                Plate[i].Width = 100 - (n - i) * 10;
                Plate[i].Height = PlateHeight;
                Plate[i].Tag = i;                //设置盘片编号
                Plate[i].Image = new Bitmap(@"..\..\Plate.bmp");   //盘子图片
                Plate[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Plate[i].Parent = pictureBox1;
                Plate[i].MouseMove += new MouseEventHandler(plate_MouseMove);
                Plate[i].MouseUp += plate_MouseUp;
                Plate[i].MouseDown += plate_MouseDown;
            }
            for (i = n; i >= 1; i += -1)
            {
                A.Add(i);      //A数组列表添加条目 
            }
        }
        private void plate_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //处理盘子移动的公共事件 
            PictureBox p1;
            p1 = (PictureBox)sender;      //将被点击的PictureBox赋给定义的p1变量 
            if (isDragging)
            {
                p1.Left = p1.Left - x1 + e.X;
                p1.Top = p1.Top - y1 + e.Y;
            }
        }
        private void plate_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)  //手动控制游戏
        {
            //处理盘子MouseDown的公共事件
            PictureBox p1;
            p1 = (PictureBox)sender;//将被点击的PictureBox赋给定义的p1变量 
            int sText;
            sText = Convert.ToInt16(p1.Tag);    //获取盘片编号 
            //首先判断是否不是最上面的盘子 
            if (A.Contains(sText))
            {
                foreach (int i in A)
                {
                    if (i < sText)
                    {
                        MessageBox.Show("请选择最上面的盘子");
                        return;
                    }
                }
            }
            if (B.Contains(sText))
            {
                foreach (int i in B)
                {
                    if (i < sText)
                    {
                        MessageBox.Show("请选择最上面的盘子");
                        return;
                    }
                }
            }
            if (C.Contains(sText))
            {
                foreach (int i in C)
                {
                    if (i < sText)
                    {
                        MessageBox.Show("请选择最上面的盘子");
                        return;
                    }
                }
            }
            //最上方的盘片 
            System.Windows.Forms.Cursor.Current = Cursors.Hand;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                x1 = e.X; y1 = e.Y;
                oldx = p1.Left; oldy = p1.Top;
                isDragging = true;
            }
        }
        private void plate_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)    //手动控制游戏的规则
        {
            //处理盘子MouseUp的公共事件
            if (!isDragging) return;
            isDragging = false;
            int sText;
            PictureBox p1;
            bool cango = false;
            p1 = (PictureBox)sender;     //将被点击的PictureBox赋给定义的p1变量 
            sText = Convert.ToInt16(p1.Tag); //获取盘片编号 
            //盘片移到B柱 
            if ((p1.Left + p1.Width / 2) >= 150 + 80 & (p1.Left + p1.Width / 2) < 320 + 80)
            {
                if (B.Count == 0 || sText < (int)B[B.Count - 1])
                {
                    //小于已有盘片 
                    B.Add(sText);
                    Plate[sText].Top = 150 - (B.Count - 1) * Plate[sText].Height;
                    if (A.Contains(sText))
                    {         //从A柱到B柱 
                        A.Remove(sText);
                        Plate[sText].Left = oldx + 170;
                    }
                    if (C.Contains(sText))
                    {         //从C柱到B柱 
                        C.Remove(sText);
                        Plate[sText].Left = oldx - 170;
                    }
                    cango = true;
                }
            }
            //盘片移到C柱 
            if ((p1.Left + p1.Width / 2) >= 320 + 80 & (p1.Left + p1.Width / 2) < 490 + 80)
            {
                if (C.Count == 0 || sText < (int)C[C.Count - 1])
                {
                    //小于已有盘片 
                    C.Add(sText);
                    Plate[sText].Top = 150 - (C.Count - 1) * Plate[sText].Height;
                    if (B.Contains(sText))
                    {        //从B柱到C柱 
                        B.Remove(sText);
                        Plate[sText].Left = oldx + 170;
                    }
                    if (A.Contains(sText))
                    {         //从A柱到C柱 
                        A.Remove(sText);
                        Plate[sText].Left = oldx + 340;
                    }
                    cango = true;
                }
            }
            //盘片移到A柱 
            if ((p1.Left + p1.Width / 2) >= 100 - 80 & (p1.Left + p1.Width / 2) < 150 + 80)
            {
                if (A.Count == 0 || sText < (int)A[A.Count - 1])
                {
                    //小于已有盘片 
                    A.Add(sText);
                    Plate[sText].Top = 150 - (A.Count - 1) * Plate[sText].Height;
                    if (B.Contains(sText))
                    {          //从B柱到A柱 
                        B.Remove(sText);
                        Plate[sText].Left = oldx - 170;
                    }
                    if (C.Contains(sText))
                    {           //从C柱到A柱 
                        C.Remove(sText);
                        Plate[sText].Left = oldx - 340;
                    }
                    cango = true;
                }
            }
            if (cango == false)
            {
                //盘片恢复到原位址 
                p1.Left = oldx;
                p1.Top = oldy;
            }
            success();
        }   //手动控值
        private void success()
        {
            if (C.Count == Convert.ToInt16(textBox1.Text))
            {
                MessageBox.Show("你成功了", "祝贺你");
            }
        }



        private void Hanoi(int n, char x, char y, char z)
        {
            if (n == 1)
            {
                MoveDisc(x, 1, z);//编号为1的盘子从x到z
            }
            else
            {
                Hanoi(n - 1, x, z, y); //n-1个盘子从x经z到y，
                MoveDisc(x, n, z);//编号为n的盘子从x到z 
                Hanoi(n - 1, y, x, z); //n-1个盘子从y经x到z，
            }
        }

        private void MoveDisc(char x, int n, char z)
        {
            int j, t = 0;
            i = i + 1;
            this.Text = i + ":Move disc " + n + " from " + x + " to " + z;  //窗体最上栏出现
            //从源柱对应数组列表中删除盘片n 
            if (x.Equals('A')) A.Remove(n);
            if (x.Equals('B')) B.Remove(n);
            if (x.Equals('C')) C.Remove(n);
            //向目标柱对应数组列表中添加盘片n 
            switch (z)
            {
                case 'A':
                    A.Add(n); t = A.Count;
                    break;
                case 'B':
                    B.Add(n); t = B.Count;
                    break;
                case 'C':
                    C.Add(n); t = C.Count;
                    break;
            }
            //动画效果移动棋子 
            int oldtop, newtop, step1;
            oldtop = Plate[n].Top;
            //首先垂直方向向上移动到顶部 
            newtop = 0;
            for (j = oldtop; j >= newtop; j -= 1)
            {
                Plate[n].Top = Plate[n].Top - 1;
                System.Windows.Forms.Application.DoEvents();
            }
            //其次水平方向移动 
            step1 = (z - x) / Math.Abs(z - x);
            for (j = 0; j <= Math.Abs(z - x) * 170; j += 1) //柱子之间间隔170像素
            {

                Plate[n].Left = Plate[n].Left + step1;
                System.Windows.Forms.Application.DoEvents();
            }
            //再垂直方向向下移动 
            oldtop = 0;
            newtop = pictureBox1.Height - (t + 1) * PlateHeight;//  167 - t * PlateHeight;
            step1 = (newtop - oldtop) / Math.Abs(newtop - oldtop);
            for (j = oldtop; j <= newtop; j += step1)
            {
                Plate[n].Top = Plate[n].Top + step1;
                System.Windows.Forms.Application.DoEvents();
            }
        }





        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //开始游戏 
            int n = Convert.ToInt16(textBox1.Text);
            load_plate(n);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(textBox1.Text);
            load_plate(n);
            int Num;
            char x = 'A';
            char y = 'B';
            char z = 'C';
            i = 0;
            try
            {
                Num = n;
                Hanoi(Num, x, y, z);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入合适的数量!", "warn");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Me.Text = e.X & " " & e.Y 
        }

    }
}
