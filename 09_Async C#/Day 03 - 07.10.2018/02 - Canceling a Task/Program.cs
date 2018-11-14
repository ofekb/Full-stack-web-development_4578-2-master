using System;
using System.Threading;
using System.Threading.Tasks;

namespace Canceling_a_Task
{
    class Program
    {
        static void GenerateNumbers(object obj)
        {
            CancellationTokenSource cts = obj as CancellationTokenSource;

            int i = 0;

            while(true)
            {
                Console.Write(i++);
                Thread.Sleep(250);

                cts.Token.ThrowIfCancellationRequested();
            }
        }

        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task t = new Task(GenerateNumbers, cts);
            t.Start();

            Thread.Sleep(2000);
            Console.WriteLine("Canceling the task");

            try
            {
                cts.Cancel();
                t.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (Exception item in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
            }
        }
    }
}