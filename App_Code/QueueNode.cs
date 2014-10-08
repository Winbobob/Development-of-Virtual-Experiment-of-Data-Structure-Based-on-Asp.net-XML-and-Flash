using System;
namespace QueueDs
{
  public class QueueNode<T>  
  {
    private T data; //������
    private QueueNode<T> next; //������
    //���캯��
    public QueueNode(T val, QueueNode<T> p)
    {
      data = val;
      next = p;
    }
    //���캯��
    public QueueNode(QueueNode<T> p)
    {
      next = p;
    }
    //���캯��
    public QueueNode(T val)
    {
      data = val;
      next = null;
    }
    //���캯��
    public QueueNode()
    {
      data = default(T);
      next = null;
    }
    //����������
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
    //����������
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
