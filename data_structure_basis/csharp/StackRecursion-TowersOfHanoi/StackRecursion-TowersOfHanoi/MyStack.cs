using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;

namespace StackRecursion_TowersOfHanoi
{
    public class MyStack
    {
        Clist Cl = new Clist();
        /// <summary>
        /// 压栈
        /// </summary>
        public void Push(int StackValue)
        {
            Cl.Append(StackValue);
        }
        /// <summary>
        /// 出栈
        /// </summary>
        public void Pop()
        {
            Cl.MoveLast();
            Cl.Delete();
        }
        /// <summary>
        /// 清空栈
        /// </summary>
        public void ClearStack()
        {
            Cl.Clear();
        }
        /// <summary>
        /// 获取栈的长度
        /// </summary>
        public int GetLength()
        {
            return Cl.ListCount;
        }
        /// <summary>
        /// 获取栈顶值
        /// </summary>
        /// <returns></returns>
        public int Top()
        {
            //Cl.MoveFrist();
            return Cl.GetHead();
        }
        /// <summary>
        /// 判断是否为空栈
        /// </summary>
        /// <returns></returns>
        public  bool IsEmpty()
        {
            return Cl.IsNull();
        }
        /// <summary>
        /// 移动到下一个
        /// </summary>
        public void NextStack()
        {
            Cl.MoveNext();
        }
        /// <summary>
        /// 获得当前栈的值
        /// </summary>
        /// <returns></returns>
        public int GetCurrentValue()
        {
            return Cl.GetCurrentValue();
        }
        /// <summary>
        /// 移动到顶
        /// </summary>
        public void MoveHaid()
        {
            Cl.MoveFrist();
        }
    }
}