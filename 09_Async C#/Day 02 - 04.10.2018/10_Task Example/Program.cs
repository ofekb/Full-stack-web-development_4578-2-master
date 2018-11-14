using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Example
{
    class Program
    {

        static void Print()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Print);
            Task t2 = new Task(Print);

            t1.Start();
            t2.Start();
            Console.WriteLine("\n-------------After Start--------");
            Console.WriteLine($"t1.IsCompleted: {t1.IsCompleted}, t2.IsCompleted: {t2.IsCompleted}");


            t1.Wait(); // The Main will wait for t1 to end.
            t2.Wait(); // The Main will wait for t2 to end.
            Console.WriteLine("\n-------------After Wait--------");
            Console.WriteLine($"t1.IsCompleted: {t1.IsCompleted}, t2.IsCompleted: {t2.IsCompleted}");
        }
    }
}
