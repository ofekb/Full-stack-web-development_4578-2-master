using System;
using System.Threading;

namespace _09_Thread_pool
{
    class Program
    {
        static void Main(string[] args)
        {

            //ThreadPool: Provides a pool of threads that can be used to execute tasks, post work items,
            //process asynchronous I/O, wait on behalf of other threads, and process timers.

            ThreadPool.GetMaxThreads(out int worker, out int complete);
            Console.WriteLine($"worker: {worker}, complete:{complete}");


            Console.WriteLine(ThreadPool.QueueUserWorkItem(Func1));
        }


        static void Func1(object state)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
