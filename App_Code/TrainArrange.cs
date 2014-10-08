using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackApplication
{
    public class TrainArrange
    {
	    int k;   
        int[] p; 
	    IStack<int>[] H;   

       


        public TrainArrange(int k1, int[] p1, StackType type)
	    {
            this.k = k1;
            this.p = p1;
	        switch (type)
            {	           
               case StackType.SeqStack:
                  H = new SeqStack<int>[k + 1];
                  for (int s = 1; s <= k; s++)
                     H[s] = new SeqStack<int>(p.Length);
                  break;
               case StackType.LinkStack:
                  H = new LinkStack<int>[k + 1];
                  for (int s = 1; s <= k; s++)
                     H[s] = new LinkStack<int>();
                  break;                  
           }   	
	    }
        string Msg = null;

        public bool Railroad(int[] p, int n, int k)
        {
            
            int NowOut = 1;   
            int minCheXiang = n + 1; 
            int minCheXiang_TieGui = 0;     
            for (int i = 0; i < n; i++)
            {
                if (p[i] == NowOut)
                {
                   Msg += "Move Car"+p[i]+" from input to output\n";
                    NowOut++;
                    
                    while (minCheXiang == NowOut)
                    {
                        
                        Output(ref minCheXiang, ref minCheXiang_TieGui, ref H, k, n);
                        NowOut++;
                    }
                }
                else
                {
                    if (!Hold(p[i], ref minCheXiang, ref minCheXiang_TieGui, ref H, k, n))
                        return false;
                }
            }
            return true;          

        }

        
        private void Output(ref int minCheXiang, ref int minCheXiang_TieGui, ref IStack<int>[] H, int k, int n)
        {
            
            int c;
            c = H[minCheXiang_TieGui].Pop();
            if (minCheXiang != n + 1)
            {
                Msg += "Move Car" + minCheXiang + " from holding track" + minCheXiang_TieGui + " to output\n";
            }
            
            minCheXiang = n + 1;
            for (int s = 1; s <= k; s++)
                if (!H[s].IsEmpty() && (c = H[s].GetTop()) < minCheXiang)
                {
                    minCheXiang = c;
                    minCheXiang_TieGui = s;
                }
        }

       
        private bool Hold(int c, ref int minCheXiang, ref int minCheXiang_TieGui, ref IStack<int>[] H, int k, int n)
        {
            int BestTrack = 0;  
            int BestTop = n + 1;  
            int x;                
            for (int s = 1; s <= k; s++)
                if (!H[s].IsEmpty())
                {
                    x = H[s].GetTop();
                    if (c < x && x < BestTop)
                    {
                        BestTop = x;
                        BestTrack = s;
                    }
                }
                else
                {
                    if (BestTrack == 0) BestTrack = s;
                    break;  
                }
          
            if (BestTrack == 0) return false;
           
            H[BestTrack].Push(c);
            Msg +="Move Car"+c+" from input to holding track"+BestTrack+"\n";
           
            if (c < minCheXiang) { minCheXiang = c; minCheXiang_TieGui = BestTrack; }
            return true;
        }

        public string ShowMsg()
        {
            return Msg;
        }
    }
}
