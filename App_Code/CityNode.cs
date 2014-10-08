using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySiteLibrary
{


   public class CityNode<T>         
    {                                
        private T data; //数据域
        private CityNode<T> next; //引用域
        //private T a;
        public CityNode(T val, CityNode<T> p)
        {
            data = val;
            next = p;
        }
        public CityNode(CityNode<T> p)
        {
            next = p;
        }
        public CityNode(T val)
        {
            data = val;
            next = null;
        }
        public CityNode()
        {
            data = default(T);
            next = null;
        }

     

        //数据域属性
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        //引用域属性
        public CityNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
