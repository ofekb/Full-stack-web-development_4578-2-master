using System;
using System.Threading;
using System.Threading.Tasks;

namespace Canceling_a_Task
{
    class Program
    {
        // CancellationTokenSource - Signals to a CancellationToken that it should be canceled.
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Print()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(100);

                // זריקת חריגה המציינת שהמטלה בוטלה
                cts.Token.ThrowIfCancellationRequested();
            }
        }

        static void Main(string[] args)
        {
            Task t = new Task(Print);
            t.Start();

            Thread.Sleep(2000);
            Console.WriteLine("Canceling the task...");

            try
            {
                // Cancel - Communicates a request for cancellation.
                cts.Cancel();

                t.Wait();
            }
            catch(AggregateException ex)
            {
                foreach (Exception item in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                    Console.WriteLine(item.GetType().Name);
                }
            }
        }
    }
}
