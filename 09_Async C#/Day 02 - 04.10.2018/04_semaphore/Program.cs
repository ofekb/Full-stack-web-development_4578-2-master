using System;
using System.Collections.Generic;
using System.Threading;

namespace _04_Threads
{
    class Program
    {
        static Semaphore MySemaphore = new Semaphore(2, 2, "MyRes");
        static List<string> StrList = new List<string>();

        static void Func1()
        {
            MySemaphore.WaitOne();
            for (int i = 0; i < 9; i++)
            {
                Thread.Sleep(3000);
                StrList.Add($"{Thread.CurrentThread.Name} {i}");

            }
            MySemaphore.Release();
        }

        static void Func2()
        {
            MySemaphore.WaitOne();
            StrList.ForEach(n => { Console.WriteLine(n); });
            MySemaphore.Release();
        }

        static void Main(string[] args)
        {

            Thread t1 = new Thread(Func1) { Name="t1"};
            Thread t2 = new Thread(Func1) { Name = "t2" };
            Thread t3 = new Thread(Func2);
            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}
