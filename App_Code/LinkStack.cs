using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackApplication
{
    public class LinkStack<T> : IStack<T>
    {
        private StackNode<T> top;
        private int size;

        public StackNode<T> Top
        {
            get { return top; }
            set { top = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public LinkStack()
        {
            top = null;
            size = 0;
        }

        public void Push(T item)
        {
            StackNode<T> q = new StackNode<T>(item);
            if (top == null)
            {
                top = q;
            }
            else
            {
                q.Next = top;
                top = q;
            }
            ++size;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            StackNode<T> p = top;
            top = top.Next;
            --size;
            return p.Data;
        }

        public T GetTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            return top.Data;
        }

        public int GetLength()
        {
            return size;
        }

        public void Clear()
        {
            top = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            if ((top == null) && (size == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
