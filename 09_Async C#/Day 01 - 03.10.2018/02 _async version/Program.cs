using System;
using System.Threading;

namespace Threads_Example
{
    class Program
    {
        static void Print1(object limit)
        {

            string threadDescription = "Print1 ThreadID: " +
                Thread.CurrentThread.ManagedThreadId +
                " Thread name: " +
                Thread.CurrentThread.Name;

            Console.WriteLine("\n ----------START "+ threadDescription);

            for (int i = 0; i < (int)limit; i++)
            {
                Console.WriteLine($"Print1 in thread {Thread.CurrentThread.Name} - iteration number {i}");
                Thread.Sleep(50); // Delay - milliseconds
            }

            Console.WriteLine("\n ----------END " + threadDescription);
        }

        static void Print2()
        {
            string threadDescription = "Print2 ThreadID: " +
                Thread.CurrentThread.ManagedThreadId +
                " Thread name: " +
                Thread.CurrentThread.Name;

            Console.WriteLine("\n ----------START " + threadDescription);
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Print2 in thread {Thread.CurrentThread.Name}- iteration number {i}");
                Thread.Sleep(50); // Delay to current thread- milliseconds

            }
            Console.WriteLine("\n ----------END " + threadDescription);
        }


        //Main is the "Main thread" by default
        static void Main(string[] args) // The Main Thread
        {

            Console.WriteLine("START Main ThreadID: " + Thread.CurrentThread.ManagedThreadId);

            //יצירה של תהליכון נוסף 
            //ביצירת התהליכון נקשר אליו את הפונקציה שתופעל על ידו
            Thread t1 = new Thread(Print1);
            Thread t2 = new Thread(Print1);
            Thread t3 = new Thread(Print2);

            //הקצאת עדיפות לתהליכון שיצרנו
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;


            /*
             * if IsBackground is true - the thread will be dead when there is no other threads in the current proccess
             * if IsBackground is false - the thread will stay alive (also if when there is no other threads in the current proccess)
             */
            t1.IsBackground = false; // This is the default.
            t2.IsBackground = true;
            t3.IsBackground = false;

            // the name of the thread is used for debugging
            t1.Name = "t1 thread";
            t2.Name = "t2 thread";
            t3.Name = "t3 thread";

            //הפעלה של התהליכון
            /*
             * יש שתי דרכים להפעיל את התהליכון:
                public void Start();  --> בלי פרמטרים
                public void Start(object parameter);  -->  פרמטר אחד - אובייקט
             */
            t1.Start(2);
            t2.Start(25);
            t3.Start();
            Console.WriteLine("END of Main");
        }
    }
}
