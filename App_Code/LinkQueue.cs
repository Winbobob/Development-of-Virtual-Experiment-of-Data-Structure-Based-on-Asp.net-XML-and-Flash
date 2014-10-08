using System;
namespace QueueDs
{
  public class LinkQueue<T>:IQueue<T> 
  {
    private static QueueNode<T> front; //队列头指示器 
    private static QueueNode<T> rear; //队列尾指示器 
    public int size; //队列结点个数 
    //队头属性 
    public QueueNode<T> Front
    {
      get
      {
        return front;
      }
      set
      {
        front = value;
      }
    }
    //队尾属性 
    public QueueNode<T> Rear
    {
      get
      {
        return rear;
      }
      set
      {
        rear = value;
      }
    }
    //队列结点个数属性 
    public int Size
    {
      get
      {
        return size;
      }
      set
      {
        size = value;
      }
    }
    //LinkDancingQueue
    public LinkQueue()
    {
      front = rear = null;
      size = 0;
    }
    //入队操作
    public void EnQueue(T item)
    {
      QueueNode<T> q = new QueueNode<T>(item);
      if (IsEmpty())
      {
        front=q;
        rear = q;
      }
      else
      {
        rear.Next = q;
        rear = q;
      }

      ++size;
    }
    //出队操作
    public T DeQueue()
    {
      if (IsEmpty())
      {
        return default(T);
      }
      QueueNode<T> p = front;
      front = front.Next;
      if (front == null)
      {
        rear = null;
      }
      --size;
      return p.Data;
    }
    //获取链队列头结点的值 
    public T GetFront()
    {
      if (IsEmpty())
      {
        return default(T);
      }
      return front.Data;
    }
    //求链队列的长度 
    public int GetLength()
    {
      return size;
    }
    //清空链队列 
    public void Clear()
    {
      front = rear = null;
      size = 0;
    }
    //判断链队列是否为空 
    public bool IsEmpty()
    {
      if ((front == rear) && (size == 0))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    
    public bool IsFull() { return false; }
  } 
}
