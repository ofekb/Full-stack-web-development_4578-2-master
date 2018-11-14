using System;
using System.Threading;

namespace _00_Threads
{


    class Program
    {
        static Thread t1 = new Thread(Func1);
        static Thread t2 = new Thread(Func2);


        static void Func1()
        {
            Console.WriteLine("Func1 START");
            t2.Suspend();  //Suspend (deprecated) - enter t2 to sleep mode
            Thread.Sleep(5000);
            Console.WriteLine("Func1 END");
            t2.Resume();  //Resume (deprecated) - exit t2 from sleep mode
        }

        static void Func2()
        {
            Console.WriteLine("Func2 START");
            Thread.Sleep(4000);
            Console.WriteLine("Func2 END");
        }
        static void Main(string[] args)
        {
            t1.Start();
            t2.Start();
        }
    }
}
