using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackApplication
{
    public class SeqStack<T> : IStack<T>
    {
        private int maxsize;
        private T[] data;
        private int top;

        public int Maxsize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }

        public int Top
        {
            get { return top; }
        }

        public SeqStack(int size)
        { 
            maxsize = size;
            data = new T[maxsize];
            top = -1;
        }

        public void Push(T elem)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is full");
                return;
            }
            data[++top] = elem;
        }

        public T Pop()
        { 
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            return data[top--];
        }

        public T GetTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is full");
                return default(T);
            }
            return data[top];
        }

        public int GetLength()
        {
            return top + 1;
        }

        public void Clear()
        {
            top = -1;
        }

        public bool IsEmpty()
        {
            if (top == -1)
                return true;
            else
                return false;
        }

        public bool IsFull()
        { 
            if (top == maxsize - 1)
                return true;
            else
                return false;
        }
    }
}
