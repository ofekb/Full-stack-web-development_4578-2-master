using System;
using System.Collections.Generic;
using System.Threading;

namespace the_therad_lock
{
    class Program
    {

        //Queue - fifo - first in first out
        //Global - can be modified by any thread
        static Queue<int> q = new Queue<int>();


        //"Thread Main"
        static void Main(string[] args)
        {

            Thread t1 = new Thread(Add);
            t1.Start();

            Thread t2 = new Thread(Subtract);
            t2.Start();
            
            
        }

        static void Add()
        {
            Console.WriteLine("-------Add start--------");

           
            lock (q)
            {
                for (int i = 0; i < 5; i++)
                {
                    q.Enqueue(1);
                    Console.WriteLine("add: " + q.Count);
                    Thread.Sleep(500);
                }
            }


            Thread.Sleep(2500);
            Console.WriteLine("-------Add end--------");
        }


        static void Subtract()
        {

            Console.WriteLine("-------Subtract start--------");
           
            lock (q)
            {
                for (int i = 0; i < 5; i++)
                {
                    q.Dequeue();
                    Console.WriteLine("subtract: " + q.Count);
                    Thread.Sleep(800);
                }
            }

            Console.WriteLine("-------Subtract end--------");
        }


        static void ForExampleOnly()
        {

            //lock משתנה פרימיטיבי לא יכול להיות בתוך 
            int a = 9;

            //'int' is not a reference type as required by the lock statement the therad lock
            //lock (a) { }  --> COMPILATION ERROR


            //lock משתנה אובייקט יכול להיות בתוך 
            object o = new object();
            lock (o)
            {
                // o - אף תהליכון לא יכול להשתמש כרגע ב
            }
            // o -  תהליכונים אחרים יכולים להשתמש כרגע ב


            try
            {
                Monitor.Enter(o);
                //סכנה - באיזור זה יכולה להתבצע שגיאה - והמשאב לא ישוחרר
            }
            finally
            {
                Monitor.Exit(o);
            }


            //prefer using lock and not Monitor
        }
    }
}
