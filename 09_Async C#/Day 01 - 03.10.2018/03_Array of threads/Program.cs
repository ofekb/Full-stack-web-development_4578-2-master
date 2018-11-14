using System;
using System.Threading;

namespace _03_Array_of_threads
{
    class Program
    {

        static void asyncMsg(object obj)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Thread with index {obj}");
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Thread[] threadArray = new Thread[num];
            for (int i = 0; i < threadArray.Length; i++)
            {
                threadArray[i] = new Thread(asyncMsg);
                threadArray[i].Start(i);
            }
        }
    }
}
