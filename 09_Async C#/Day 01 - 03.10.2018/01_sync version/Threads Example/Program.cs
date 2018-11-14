using System;
using System.Threading;

namespace Threads_Example
{
    class Program
    {
        static void Print1(object limit)
        {
            Console.WriteLine("\nPrint1 ThreadID: " + Thread.CurrentThread.ManagedThreadId);
 
            for (int i = 0; i < (int)limit; i++)
            {
                Console.WriteLine($"Print1 - iteration number {i}");
                Thread.Sleep(5000); // Delay to current thread- milliseconds
            }
        }

        static void Print2()
        {
            Console.WriteLine("\nPrint2 ThreadID: " + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Print2 - iteration number {i}");
                Thread.Sleep(5000); // Delay to current thread- milliseconds

            }
        }


        //Main is the "Main thread" by default
        static void Main(string[] args) // The Main Thread
        {

            Console.WriteLine("Main ThreadID: " + Thread.CurrentThread.ManagedThreadId);

            Print1(3); // Sync Call - קריאה סינכרונית
            Print2(); // Sync Call - קריאה סינכרונית


            Console.WriteLine("End of Main");
        }
    }
}
