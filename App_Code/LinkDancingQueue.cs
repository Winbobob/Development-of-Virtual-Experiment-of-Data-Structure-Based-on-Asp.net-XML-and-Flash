using System;
using System.Collections.Generic;
using System.Text;

namespace QueueDs
{
  public class LinkDancingQueue:LinkQueue<int>, IDancingQueue 
  {
      private static int callnumber;
    //叫号属性
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
    //获得服务号码
    public int GetCallnumber()
    {
        callnumber++; 
        return callnumber;
    }
  }
}
