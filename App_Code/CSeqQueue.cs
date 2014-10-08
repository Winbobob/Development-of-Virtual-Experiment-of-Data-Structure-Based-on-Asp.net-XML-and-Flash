using System;
namespace QueueDs
{
    public class CSeqQueue<T> : IQueue<T> 
  {
    private static int maxsize; //ѭ��˳����е�����
    private T[] data; //���飬���ڴ洢ѭ��˳������е�����Ԫ��
    private static int front; //ָʾ���һ�������뿪���е�Ԫ����ռ��λ��
    private static int rear; //ָʾ���һ����������е�Ԫ�ص�λ��
    //������                
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
    //��������
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
    //��ͷָʾ������
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
    //��βָʾ������
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
    //��ʼ������
    public CSeqQueue() { }
    public CSeqQueue(int size)
    {
      data = new T[size];
      maxsize = size;
      front = rear = -1;
    }
    //��Ӳ���
    public void EnQueue(T elem)
    {
      
      
      if (IsFull())
      {
        return;
      }
      rear=(rear + 1) % maxsize; ;
      data[rear] = elem;
    }
    //���Ӳ���
    public T DeQueue()
    {
      if (IsEmpty())
      {
        return default(T);
      }
      front = (front + 1) % maxsize;
      return data[front];
    }
    //��ȡ��ͷ����Ԫ��
    public T GetFront()
    {
      if (IsEmpty())
      {
        return default(T);
      }
      return data[(front+1)%maxsize];
    }
    //��ѭ��˳����еĳ���
    public int GetLength()
    {
      return (rear - front + maxsize) % maxsize;
     
    }
    //�ж�ѭ��˳������Ƿ�Ϊ��
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
    //���ѭ��˳�����
    public void Clear()
    {
      front = rear = -1;
    }
    //�ж�ѭ��˳������Ƿ�Ϊ��
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
