using System;
using System.Collections.Generic;
using System.Threading;

namespace _01_Threads
{
    class Program
    {

        static List<int> NumList = new List<int>();

        static void Func1()
        {
            lock (NumList)
            {
                NumList.AddRange(new int[]{1,2,3});
            }
        }

        static void Func2()
        {
            lock (NumList)
            {
                NumList.ForEach(n => { Console.WriteLine(n); });
            }
        }
        static void Main(string[] args)
        {

            Thread t1 = new Thread(Func1);
            Thread t2 = new Thread(Func2);
            t1.Start();
            t2.Start();
        }
    }
}
