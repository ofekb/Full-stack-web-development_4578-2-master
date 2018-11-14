using System;
using System.Threading;

namespace _05_interLocked
{
    class Program
    {
        //Interlocked - Provides atomic operations for variables that are shared by multiple threads.
        static void Main(string[] args)
        {
            int num = 6;
            new Thread(
                () =>
                {
                    Thread.Sleep(2000);
                    Interlocked.Increment(ref num);
                    Console.WriteLine($"Increment: {num}");
                }).Start();

            new Thread(
           () =>
           {
               Thread.Sleep(2000);
               Interlocked.Decrement(ref num);
               Console.WriteLine($"Decrement: {num}");
           }).Start();

            new Thread(
           () =>
           {
               Thread.Sleep(2000);
               Interlocked.Exchange(ref num, 20);
               Console.WriteLine($"Exchange: {num}");
           }).Start();


            new Thread(
           () =>
           {
               Thread.Sleep(2000);
               Interlocked.CompareExchange(ref num, 20, 40);
               Console.WriteLine($"CompareExchange: {num}");
           }).Start();

        }
    }
}
