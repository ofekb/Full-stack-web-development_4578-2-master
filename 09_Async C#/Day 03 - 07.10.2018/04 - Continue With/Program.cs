using System;
using System.Threading;
using System.Threading.Tasks;

namespace Continue_With_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(()=> {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"1 {Thread.CurrentThread.ManagedThreadId} |");
                    Thread.Sleep(500);
                }
            });

            // ContinueWith - Creates a continuation that executes asynchronously 
            // when the target Task completes.
            //
            // Parameters:
            //     An action to run when the Task completes. When run, the
            //     delegate will be passed the completed task as an argument.
            //
            // Returns:
            //     A new continuation Task.
            t1.ContinueWith(t2 => {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"2 {Thread.CurrentThread.ManagedThreadId} |");
                    Thread.Sleep(500);
                }

                t2.ContinueWith(t3 => {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"3 {Thread.CurrentThread.ManagedThreadId} |");
                        Thread.Sleep(500);
                    }
                });
            });

            t1.Start();
            Console.WriteLine("Started...");

            Console.ReadLine();
        }
    }
}
