using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySiteLibrary
{
    public class CityList<T> : ILinearList<T>         
    {
        private CityNode<T> start;  
        int length;               

        public CityList()
        {
            start = null;
        }


        public void InsertNode(T a)  
        {
            if (start == null)              
            { 
                start = new CityNode<T>(a);
                length ++;
                return;                     
            }
            CityNode<T> current = start;      
            while (current.Next != null)      
            {
                current = current.Next;
            }
            current.Next = new CityNode<T>(a);
            length++;
        }


        public void InsertNode(T a, int i)
        {
            CityNode<T> current;
            CityNode<T> previous;
            if (i < 1 || i > length + 1)
            {
                Console.WriteLine("Position is error!");
                return;
            }
            CityNode<T> newnode = new CityNode<T>(a);

            if (i == 1)
            {
                newnode.Next = start;   
                start = newnode;       
                return;
            }

            current = start;
            previous = null;
            int j = 1;
            while (current != null && j < i)
            {
                previous = current;
                current = current.Next;    
                j++;
            }
            if (j == i)
            {
                previous.Next = newnode;
                newnode.Next = current;
                length++;
            }
        }


        public void DeleteNode(int i)
        {
            if (IsEmpty() || i < 1 ||i > GetLength())
            {
                Console.WriteLine("Link is empty or position is error!");
            }
            CityNode<T> current = start;
            if (i == 1)
            {
                start = current.Next;
                length--;
                return;
            }
            CityNode<T> previous = null;
            int j = 1;
            while (current != null && j < i)   
            {
                previous = current;
                current = current.Next;
                j++;
            }
            if (j == i)
            {
                previous.Next = current.Next; 
                length--;
            }
            else
            {
                Console.WriteLine("The node isn't exist!!");
            }
        }



        public T SearchNode(int i)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!!");
                return default(T);
            }
            CityNode<T> current = start;
            int j = 1;
            while (current.Next != null && j < i)
            {
                current = current.Next;
                j++;
            }
            if (j == i)
            {
                return current.Data;
            }
            else 
            {
                Console.WriteLine("The node isn't exist!!");
                return default(T);
            }
        }



        public T SearchNode(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!!");
                return default(T);
            }
            CityNode<T> current = start;
            int i = 1;
            while (!current.Data.ToString().Contains(value.ToString())&&current!=null)  
            {
                current=current.Next;
                i++;
            }
            if (current != null)
                return current.Data;
            else
                return default(T);
        }


        
        public T ReturnPoint()    
        {
            CityNode<T> current = start;
            Console.Write("请输入城市名称：");
            string cityname = Convert.ToString(Console.ReadLine());
            while (current.Data.ToString().Contains(cityname))
            {
                Console.WriteLine("{0}",current.Data.ToString());
                return default(T);
            }
            return default(T);
        }

        
        public int GetLength()
        {
            return length;
        }
       
        public void Clear()
        {
            start = null;
        }
       
        public bool IsEmpty()
        {
            if (start == null)
                return true;
            else
                return false;
        }
       
        public void Display()
        {
            CityNode<T> p = new CityNode<T>();
            p = this.start;
            while (p != null)
            {
                Console.Write(p.Data.ToString() + " ");
                p = p.Next;
            }
        }
    }

    
       
        class Match
        {
        private Dictionary<string, City> items =null;      
        public Match()
        {
            items = new Dictionary<string, City>();
        }
        public void Add(City item)
        {
           items.Add(item.Name, item);
        }

        public void Remove(City item)
        {
            items.Remove(item.Name);
        }

        public void Display()    
        {
             Console.Write("请输入城市名称：");
             string name = Convert.ToString(Console.ReadLine());
             while(items[name].Name!=null)
             {
                 Console.WriteLine("北纬{0}°,东经{1}°\n", items[name].X, items[name].Y);
                break;
             }
        }
        public void Calculate()
        {
            Console.Write("请输入城市1名称：");
            string name1 = Convert.ToString(Console.ReadLine());
            Console.Write("请输入城市2名称：");
            string name2 = Convert.ToString(Console.ReadLine());
            while (items[name1].Name != null && items[name2].Name != null)
            {
                Console.WriteLine("城市1坐标为北纬{0}°,东经{1}°", items[name1].X, items[name1].Y);
                Console.WriteLine("城市2坐标为北纬{0}°,东经{1}°", items[name2].X, items[name2].Y);
                Console.WriteLine("两城市间距离为{0}\n", System.Math.Sqrt((items[name1].X - items[name2].X) * (items[name1].X - items[name2].X) + (items[name1].Y - items[name2].Y) * (items[name1].Y - items[name2].Y)));
                break;
            }
        }
    }
}

