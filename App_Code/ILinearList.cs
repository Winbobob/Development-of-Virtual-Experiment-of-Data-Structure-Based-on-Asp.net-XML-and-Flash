using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySiteLibrary
{
    public interface ILinearList<T> 
    {
        void InsertNode(T a, int i);  //插入操作1
        void InsertNode(T a);         //插入操作2
        void DeleteNode(int i);       //删除操作
        T SearchNode(int i);          //查找表元素
        T SearchNode(T value);        //定位元素
       // T ReturnPoint(); //输入城市名返回一个完整泛型 
        int GetLength();              //求表长度
        void Display();        //显示链表
        void Clear();                 //清空操作
        bool IsEmpty();               //判断线性表是否为空
    }
}
