using System;
using System.Threading;
using System.Threading.Tasks;
namespace _09_async_await
{
    class Program
    {
        public static void Main()
        {
            Task<Task<string>> t1 = new Task<Task<string>>(Res2);
            t1.Start();
       
            Console.WriteLine(t1.Result.Result);
        }

        private static async Task<int> Res1()
        {
            Thread.Sleep(2000);
            return await Task.FromResult(1000);
        }

        private static async Task<string> Res2()
        {
            return $"Ok: {await Res1()}";
        }
    }


}

