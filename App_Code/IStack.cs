using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackApplication
{
    interface IStack<T>
    {
        void Push(T item);
        T Pop();
        T GetTop();
        int GetLength();
        bool IsEmpty();
        void Clear();
    }
}
