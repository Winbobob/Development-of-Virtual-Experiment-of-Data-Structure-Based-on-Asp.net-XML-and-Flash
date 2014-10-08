using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySiteLibrary
{
    public class City               
    {
        public string name;
        public double x;   
        public double y;  
        public City(string name, double x, double y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

     
        public override string ToString()    
        { 
           return "城市名称为："+name+"城市坐标为：("+x.ToString()+","+y.ToString()+")\n"; 
        }
    }
}
