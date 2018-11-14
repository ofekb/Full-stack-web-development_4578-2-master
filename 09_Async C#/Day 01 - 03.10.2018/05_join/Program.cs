using System;
using System.Threading;

namespace _05_join
{
    class Program
    {
        static void Test()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} START");
            Thread.Sleep(5000);
            Console.WriteLine($"{Thread.CurrentThread.Name} END");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main START");

            Thread t1 = new Thread(Test) { Name = "t1" };
            Thread t2 = new Thread(Test) { Name = "t2" };
            Thread t3 = new Thread(Test) { Name = "t3" };

            t1.Start();
            t1.Join();

            t2.Start();
            t2.Join();
            
            t3.Start();
            t3.Join();
            Console.WriteLine("Main END");
        }
    }
}
