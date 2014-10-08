using System;
namespace QueueDs
{
  public interface IQueue<T>  
  {
    void EnQueue(T elem); //入队列操作
    T DeQueue(); //出队列操作
    T GetFront(); //取对头元素
    int GetLength(); //求队列的长度
    bool IsEmpty(); //判断队列是否为空
    void Clear(); //清空队列
    bool IsFull();//判断是否为满
  }
}
