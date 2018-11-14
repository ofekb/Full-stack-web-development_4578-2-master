using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks_and_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");

            //try
            //{
            //    int[] array = { 10, 20, 30, 40, 50 };
            //    Console.WriteLine(array[5]);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.GetType().Name);
            //}



            Task t = new Task(() => {

                Task t2 = new Task(() => {
                    Thread.Sleep(2000);
                    int a = 0, b = 1 / a;
                    Console.WriteLine("End Child");
                }, TaskCreationOptions.AttachedToParent);
                t2.Start();

                int[] array = { 10, 20, 30, 40, 50 };
                int sum = 0;
                for (int i = 0; i < array.Length+1; i++)
                {
                    sum += array[i];
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Sum: " + sum);
            });
            t.Start();

            try
            {
                t.Wait(); // catch-אם תתבצע חריגה - החריגה כן תיתפס בבלוק ה
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine("----------------------------");
                foreach (Exception item in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                    Console.WriteLine(item.GetType().Name);
                }
            }
        }
    }
}
