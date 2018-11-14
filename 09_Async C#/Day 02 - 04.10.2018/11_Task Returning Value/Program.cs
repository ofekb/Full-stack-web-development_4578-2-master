using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Returning_Value
{
    class Program
    {
        static int GetSummary(object maxNumber)
        {
            int sum = 0;
            for (int i = 1; i <= (int)maxNumber; i++)
            {
                sum += i;
                Thread.Sleep(50);
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Task<int> t = new Task<int>(GetSummary, 70);
            t.Start();
            Console.WriteLine("Task Started.");
            int result = t.Result; // Waiting for the task to complete
            Console.WriteLine("Result: " + result);
        }
    }
}
