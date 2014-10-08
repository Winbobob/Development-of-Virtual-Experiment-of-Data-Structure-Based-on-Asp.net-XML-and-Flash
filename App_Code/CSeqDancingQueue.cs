using System;
using System.Threading;
namespace QueueDs
{
  
   public class CSeqDancingQueue:CSeqQueue<int>,IDancingQueue 
  {
      private static int callnumber;
    public int Callnumber
    {
      get
      {
        return callnumber;
      }
      set
      {
        callnumber = value;
      }
    }
    public CSeqDancingQueue (){}
    public CSeqDancingQueue(int size):base(size){}
    //��÷������
    public int GetCallnumber()
    {
        callnumber++; 
        return callnumber;
    }
  }
 }
