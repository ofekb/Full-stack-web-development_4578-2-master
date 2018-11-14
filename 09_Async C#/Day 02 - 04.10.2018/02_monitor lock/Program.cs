using System;
using System.Collections.Generic;
using System.Threading;

namespace _02_Threads
{
    class Program
    {

        static List<int> NumList = new List<int>();

        static void Func1()
        {
            Monitor.Enter(NumList);
            NumList.AddRange(new int[] { 1, 2, 3 });
            Monitor.Exit(NumList);
        }

        static void Func2()
        {
            Monitor.Enter(NumList);
            NumList.ForEach(n => { Console.WriteLine(n); });
            Monitor.Exit(NumList);
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
