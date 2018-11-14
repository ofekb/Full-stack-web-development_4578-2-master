using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Collections_and_Tasks
{
    class Program
    {
        static List<string> List1 = new List<string>();

        //ConcurrentBag - Represents a thread-safe, unordered collection 
        static ConcurrentBag<string> List2 = new ConcurrentBag<string>();


        

        static void AddNumbers()
        {

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                List1.Add($"{Thread.CurrentThread.ManagedThreadId} : {i}");
            }


            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                List2.Add($"{Thread.CurrentThread.ManagedThreadId} : {i}");
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(AddNumbers);
            Task t2 = new Task(AddNumbers);
            t1.Start();
            t2.Start();
            t1.Wait();
            t2.Wait();

            Console.WriteLine("--------------List1--------------");
            foreach (string item in List1)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("--------------List2--------------");
            foreach (string item in List2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
