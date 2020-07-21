using System;
using System.Collections.Generic;

namespace EventExample
{
    
    public class GenericList<T>
    {
        List<T> collection;
        public GenericList()
        {
            collection = new List<T>();
        }
        public void Add(T item)
        {
            collection.Add(item);
        }

        public T ElementAt(int position)
        {
            return collection[position];
        }

        public void SortInPlace()
        {
            collection.Sort();
        }
    }
    
    class Program
    {

        static void Main(string[] args)
        {
            //un event nu poate fi in dreapta unui semn pur de asignare, adica =, poate fi in dreapta la += sau -=
            Console.WriteLine("Hello World!");
            GenericList<int> lst = new GenericList<int>();
            lst.Add(3);
            lst.Add(5);
            Console.WriteLine(lst.ElementAt(1));
            //var sec = new Second();
            //List<object> lst = new List<object>();
            //lst.Add(sec);
            //foreach(var i in lst)
            //{
            //    Second temp = (Second)i;
            //    temp.show("Data");
            //}
            //var sec = new Second();
            //sec.simpleEv += A;
            //sec.simpleEv += A;
            //sec.callEv();
            //sec.useDel();
        }

        static void A(object sender, EventArgs e)
        {
            Console.WriteLine("Simple display");
        }
    }
}
