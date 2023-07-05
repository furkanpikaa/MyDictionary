using System;
using System.Collections.Generic;
using System.Text;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
           

            MyDictionary<int,string> myDictionary1 = new MyDictionary<int,string>();

            myDictionary1.Add(1, "Furkan");
            myDictionary1.Add(2, "Murat");
            myDictionary1.Add(3, "Beyza");

            foreach(MyKeyValuePair<int,string> x in myDictionary1)
            {
                Console.WriteLine("Değer = {0}, İsim = {1}",x.Key, x.Value);
            }

            Console.ReadLine();
        }
    }

    public class MyKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class MyDictionary<TKey, TValue>
    {
        private MyKeyValuePair<TKey, TValue>[] items;

        public MyDictionary()
        {
            items = new MyKeyValuePair<TKey, TValue>[0];
        }

        public void Add(TKey key, TValue value)
        {
            MyKeyValuePair<TKey, TValue>[] tempItems = items;
            items = new MyKeyValuePair<TKey, TValue>[items.Length + 1];
            for (int i = 0; i < tempItems.Length; i++)
            {
                items[i] = tempItems[i];
            }

            items[items.Length - 1] = new MyKeyValuePair<TKey, TValue>(){Key = key ,Value = value};

        }

        public IEnumerator<MyKeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (MyKeyValuePair<TKey, TValue> item in items)
            {
                yield return item;
            }
        }
    }
}

