using System;
namespace QueueDs
{
    public class CSeqQueue<T> : IQueue<T> 
  {
    private static int maxsize; //循环顺序队列的容量
    private T[] data; //数组，用于存储循环顺序队列中的数据元素
    private static int front; //指示最近一个己经离开队列的元素所占的位置
    private static int rear; //指示最近一个进行入队列的元素的位置
    //索引器                
    public T this[int index]
    {
      get
      {
        return data[index];
      }
      set
      {
        data[index] = value;
      }
    }
    //容量属性
    public int Maxsize
    {
      get
      {
        return maxsize;
      }
      set
      {
        maxsize = value;
      }
    }
    //队头指示器属性
    public int Front
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
    //队尾指示器属性
    public int Rear
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
    //初始化队列
    public CSeqQueue() { }
    public CSeqQueue(int size)
    {
      data = new T[size];
      maxsize = size;
      front = rear = -1;
    }
    //入队操作
    public void EnQueue(T elem)
    {
      
      
      if (IsFull())
      {
        return;
      }
      rear=(rear + 1) % maxsize; ;
      data[rear] = elem;
    }
    //出队操作
    public T DeQueue()
    {
      if (IsEmpty())
      {
        return default(T);
      }
      front = (front + 1) % maxsize;
      return data[front];
    }
    //获取队头数据元素
    public T GetFront()
    {
      if (IsEmpty())
      {
        return default(T);
      }
      return data[(front+1)%maxsize];
    }
    //求循环顺序队列的长度
    public int GetLength()
    {
      return (rear - front + maxsize) % maxsize;
     
    }
    //判断循环顺序队列是否为满
    public bool IsFull()
    {
      if ((front == -1 && rear == maxsize - 1) || (rear + 1) % maxsize == front)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    //清空循环顺序队列
    public void Clear()
    {
      front = rear = -1;
    }
    //判断循环顺序队列是否为空
    public bool IsEmpty()
    {
      if (front == rear)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
