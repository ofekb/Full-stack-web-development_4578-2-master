using System;
using System.Threading;
using System.Threading.Tasks;

namespace Continue_With
{
    class Program
    {
        static void Print()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(Thread.CurrentThread.ManagedThreadId+ "");
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Print);
            Task t2 = new Task(Print);
            Task t3 = new Task(Print);

            t1.ContinueWith(obj => t2.Start());
            t2.ContinueWith(obj => t3.Start());
            t3.ContinueWith(obj => Console.WriteLine("t3 end msg"));

            t1.Start();

            Console.WriteLine("Started");

            t1.Wait();
            t2.Wait();
            t3.Wait();

            Console.WriteLine("End");
        }
    }
}
