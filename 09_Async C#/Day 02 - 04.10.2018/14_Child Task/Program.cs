using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Child_Task
{
    class Program
    {
       
        
        static void PrintNumbers(object maxNumber)
        {
            Task t1 = new Task(() => {
                for (int i = 2; i <= (int)maxNumber; i += 2)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(100);
                }
            }, TaskCreationOptions.AttachedToParent);
            Task t2 = new Task(() => {
                for (int i = 1; i <= (int)maxNumber; i += 2)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(100);
                }
            }, TaskCreationOptions.AttachedToParent);

            t1.Start();
            t2.Start();
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Task t = new Task(PrintNumbers, 100);
            t.Start();

            t.Wait();

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
