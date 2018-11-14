using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks_Example_Continue
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() => {
                for (int i = 1; i <= 5; i++)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(1000);
                }
            });

            Task t2 = new Task(n => {
                for (int i = 1; i <= (int)n; i++)
                {
                    Console.Write(-i + " ");
                    Thread.Sleep(1000);
                }
            }, 5);

            t1.Start();
            t2.Start();

            Console.WriteLine("Task Started");

            t1.Wait();
            t2.Wait();

            Console.WriteLine("End of Main");
        }
    }
}
