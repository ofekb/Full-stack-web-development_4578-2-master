using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_ForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            ParallelOptions po = new ParallelOptions();

            // MaxDegreeOfParallelism -the maximum number of concurrent tasks enabled by this ParallelOptions
            po.MaxDegreeOfParallelism = 3;



            //  Parallel.ForEach - Executes a foreach operation on an IEnumerable
            //  in which iterations may run in parallel and loop options can be configured.
            //
            // Parameters:
            //   source:
            //     An enumerable data source.
            //
            //   parallelOptions:
            //     An object that configures the behavior of this operation.
            //
            //   body:
            //     The delegate that is invoked once per iteration.
            //
            // Returns:
            //     A structure that contains information about which portion of the loop completed.
            //
            Parallel.ForEach(array, po, item => {
                Console.WriteLine("item = {0}, ThreadID = {1}, TaskID = {2}",
                    item, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(1000);
            });
        }
    }
}
