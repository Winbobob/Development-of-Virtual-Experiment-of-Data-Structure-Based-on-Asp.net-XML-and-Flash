using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackApplication
{
    public class StackNode<T>
    {
        private T data;
        private StackNode<T> next;

        public StackNode()
        {
            data = default(T);
            next = null;

        }

        public StackNode(T val)
        {
            data = val;
            next = null;
        }

        public StackNode(T val, StackNode<T> p)
        {
            data = val;
            next = p;
        }

        public T Data
        {
            get { return data;  }
            set { data = value; }
        }

        public StackNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
