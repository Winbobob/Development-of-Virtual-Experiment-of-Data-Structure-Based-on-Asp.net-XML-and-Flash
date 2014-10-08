using System;
namespace QueueDs
{
  public class LinkQueue<T>:IQueue<T> 
  {
    private static QueueNode<T> front; //����ͷָʾ�� 
    private static QueueNode<T> rear; //����βָʾ�� 
    public int size; //���н����� 
    //��ͷ���� 
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
    //��β���� 
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
    //���н��������� 
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
    //��Ӳ���
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
    //���Ӳ���
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
    //��ȡ������ͷ����ֵ 
    public T GetFront()
    {
      if (IsEmpty())
      {
        return default(T);
      }
      return front.Data;
    }
    //�������еĳ��� 
    public int GetLength()
    {
      return size;
    }
    //��������� 
    public void Clear()
    {
      front = rear = null;
      size = 0;
    }
    //�ж��������Ƿ�Ϊ�� 
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
