using System;
using System.Collections.Generic;
using System.Text;
namespace StackRecursion_TowersOfHanoi
{
    public class ListNode
    {
        public ListNode(int NewValue)
        {
            Value = NewValue;
        }
        public ListNode Previous;
        public ListNode Next;
       
        public int Value;
    }
        public class Clist
        {
            public Clist()
            {
                //构造函数
                //初始化
                ListCountValue = 0;
                Head = null;
                Tail = null;
            }
            private ListNode Head;
            private ListNode Tail;
            private ListNode Current;
            private int ListCountValue;
            public void Append(int DataValue)
            {
                ListNode NewNode = new ListNode(DataValue);
                if (IsNull())
                //如果头指针为空
                {
                    Head = NewNode;
                    Tail = NewNode;
                }
                else
                {
                    Tail.Next = NewNode;
                    NewNode.Previous = Tail;
                    Tail = NewNode;
                }
                Current = NewNode;
                //链表数据个数加一
                ListCountValue += 1;
            }
            public void Delete()
            {
                MoveLast();
                //若为空链表
                if (!IsNull())
                {
                    //若删除头
                    if (IsBof())
                    {
                        Head = Current.Next;
                        Current = Head;
                        ListCountValue -= 1;
                        return;
                    }
                    //若删除尾
                    if (IsEof())
                    {
                    Tail = Current.Previous;
                    Current = Tail;
                    ListCountValue -= 1;
                        return;
                    }
                    //若删除中间数据
                    Current.Previous.Next = Current.Next;
                    Current = Current.Previous;
                    ListCountValue -= 1;
                    return;
                }
            }
            public void MoveNext()
            {
                if (!IsEof()) Current = Current.Next;
            }
            public void MovePrevious()
            {
                if (!IsBof()) Current = Current.Previous;
            }
            public void MoveFrist()
            {
                Current = Head;
            }
            public void MoveLast()
            {
                Current = Tail;
            }
            public bool IsNull()
            {
                if (ListCountValue == 0)
                    return true;
                return false;
            }
            public bool IsEof()
            {
                if (Current == Tail)
                    return true;
                return false;
            }
            public bool IsBof()
            {
                if (Current == Head)
                    return true;
                return false;
            }
            public int GetCurrentValue()
            {
                return Current.Value;
            }
            public int ListCount
            {
                get
                {
                    return ListCountValue;
                }
            }
            public void Clear()
            {
                MoveFrist();
                while (!IsNull())
                {
                    //若不为空链表,从尾部删除
                    Delete();
                }
            }
            public int GetTail()
            {
                MoveLast();
                return Current.Value;
            }
            public int GetHead()
            {
                return Current.Value;
            }
            public void Insert(int DataValue)
            {
                ListNode NewNode = new ListNode(DataValue);
                if (IsNull())
                {
                    //为空表，则添加
                    Append(DataValue);
                    return;
                }
                if (IsBof())
                {
                    //为头部插入
                    NewNode.Next = Head;
                    Head.Previous = NewNode;
                    Head = NewNode;
                    Current = Head;
                    ListCountValue += 1;
                    return;
                }
                //中间插入
                NewNode.Next = Current;
                NewNode.Previous = Current.Previous;
                Current.Previous.Next = NewNode;
                Current.Previous = NewNode;
                Current = NewNode;
                ListCountValue += 1;
            }
            public void InsertAscending(int InsertValue)
            {
                //参数：InsertValue 插入的数据
                //为空链表
                if (IsNull())
                {
                    //添加
                    Append(InsertValue);
                    return;
                }
                //移动到头
                MoveFrist();
                if ((InsertValue < GetCurrentValue()))
                {
                    //满足条件，则插入，退出
                    Insert(InsertValue);
                    return;
                }
                while (true)
                {
                    if (InsertValue < GetCurrentValue())
                    {
                        //满族条件，则插入，退出
                        Insert(InsertValue);
                        break;
                    }
                    if (IsEof())
                    {
                        //尾部添加
                        Append(InsertValue);
                        break;
                    }
                    //移动到下一个指针
                    MoveNext();
                }
            }
            public void InsertUnAscending(int InsertValue)
            {
                //参数：InsertValue 插入的数据
                //为空链表
                if (IsNull())
                {
                    //添加
                    Append(InsertValue);
                    return;
                }
                //移动到头
                MoveFrist();
                if (InsertValue > GetCurrentValue())
                {
                    //满足条件，则插入，退出
                    Insert(InsertValue);
                    return;
                }
                while (true)
                {
                    if (InsertValue > GetCurrentValue())
                    {
                        //满族条件，则插入，退出
                        Insert(InsertValue);
                        break;
                    }
                    if (IsEof())
                    {
                        //尾部添加
                        Append(InsertValue);
                        break;
                    }
                    //移动到下一个指针
                    MoveNext();
                }
            }
        }
    }


