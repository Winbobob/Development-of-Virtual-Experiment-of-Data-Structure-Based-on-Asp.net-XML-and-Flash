using System;
namespace QueueDs
{
  public interface IDancingQueue:IQueue<int> 
  {
    int GetCallnumber();//获得服务号码
  }
}
