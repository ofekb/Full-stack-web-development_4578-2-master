using System;
using System.Collections.Generic;
using System.Threading;

namespace _03_Threads
{
    class Program
    {
        static Mutex MyMutex=new Mutex(false, "MyRes");
        static List<int> NumList = new List<int>();

        static void Func1()
        {
            MyMutex.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(3000);
                NumList.Add(i);

            }          
            MyMutex.ReleaseMutex();
        }

        static void Func2()
        {
            MyMutex.WaitOne();
            NumList.ForEach(n => { Console.WriteLine(n); });
            MyMutex.ReleaseMutex();
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
