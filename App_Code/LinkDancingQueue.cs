using System;
using System.Collections.Generic;
using System.Text;

namespace QueueDs
{
  public class LinkDancingQueue:LinkQueue<int>, IDancingQueue 
  {
      private static int callnumber;
    //�к�����
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
    //��÷������
    public int GetCallnumber()
    {
        callnumber++; 
        return callnumber;
    }
  }
}
