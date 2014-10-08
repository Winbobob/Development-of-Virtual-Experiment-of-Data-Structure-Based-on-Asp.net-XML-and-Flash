using System;
namespace QueueDs
{
  public interface IQueue<T>  
  {
    void EnQueue(T elem); //����в���
    T DeQueue(); //�����в���
    T GetFront(); //ȡ��ͷԪ��
    int GetLength(); //����еĳ���
    bool IsEmpty(); //�ж϶����Ƿ�Ϊ��
    void Clear(); //��ն���
    bool IsFull();//�ж��Ƿ�Ϊ��
  }
}
