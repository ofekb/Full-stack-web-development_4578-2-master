using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parralel_For
{
    class Program
    {

        // Parallel - Provides support for parallel loops and regions.

        static void Main(string[] args)
        {
            // ManagedThreadID = שרץ Thread-קוד עבור ה
            // Task.CurrentId = שרצה Task-קוד עבור ה


            // Parallel.For - Executes a for loop in which iterations may run in parallel.
            //
            // Parameters:
            //   fromInclusive:
            //     The start index, inclusive.
            //
            //   toExclusive:
            //     The end index, exclusive.
            //
            //   body:
            //     The delegate that is invoked once per iteration.
            //
            // Returns:
            //     A structure that contains information about which portion of the loop completed.
            //
            ParallelLoopResult res=Parallel.For(0, 20, i => {
                Console.WriteLine("i = {0}, ThreadID = {1}, TaskID = {2}",
                    i, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            });

            Console.WriteLine(res.IsCompleted);
        }
    }
}
