using System;
using System.Collections.Generic;
using System.Threading;

namespace the_therad_lock
{
    class Program
    {

        //Queue - fifo - first in first out
        //Global - can be modified by any thread
        static Queue<int> q1 = new Queue<int>();
        static Queue<int> q2 = new Queue<int>();

        //"Thread Main"
        static void Main(string[] args)
        {

            Thread t1 = new Thread(FuncQ1);
            t1.Start();

            Thread t2 = new Thread(FuncQ2);
            t2.Start();


        }

        static void FuncQ1()
        {
            Console.WriteLine("-------FuncQ1 start--------");


            lock (q1)
            {
                for (int i = 0; i < 5; i++)
                {
                    q1.Enqueue(1);
                    Console.WriteLine("add to q1: " + q1.Count);
                    Thread.Sleep(500);
                }

                lock (q2)
                {
                    Console.WriteLine(q2.Count);
                }
            }


            Thread.Sleep(2500);
            Console.WriteLine("-------FuncQ1 end--------");
        }


        static void FuncQ2()
        {

            Console.WriteLine("-------FuncQ2 start--------");

            lock (q2)
            {
                for (int i = 0; i < 5; i++)
                {
                    q2.Enqueue(1);
                    Console.WriteLine("add to q2: " + q2.Count);
                    Thread.Sleep(500);
                }

                lock (q1)
                {
                    Console.WriteLine(q1.Count);
                }
            }

            Console.WriteLine("-------FuncQ2 end--------");
        }

 
    }
}
