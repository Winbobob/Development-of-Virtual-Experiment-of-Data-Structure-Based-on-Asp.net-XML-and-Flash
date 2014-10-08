using System;
namespace QueueDs
{
  public class QueueNode<T>  
  {
    private T data; //数据域
    private QueueNode<T> next; //引用域
    //构造函数
    public QueueNode(T val, QueueNode<T> p)
    {
      data = val;
      next = p;
    }
    //构造函数
    public QueueNode(QueueNode<T> p)
    {
      next = p;
    }
    //构造函数
    public QueueNode(T val)
    {
      data = val;
      next = null;
    }
    //构造函数
    public QueueNode()
    {
      data = default(T);
      next = null;
    }
    //数据域属性
    public T Data
    {
      get
      {
        return data;
      }
      set
      {
        data = value;
      }
    }
    //引用域属性
    public QueueNode<T> Next
    {
      get
      {
        return next;
      }
      set
      {
        next = value;
      }
    }
  }
}
