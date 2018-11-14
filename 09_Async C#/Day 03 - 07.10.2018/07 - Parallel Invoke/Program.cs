using System;
using System.Threading.Tasks;

namespace Parallel_Invoke
{
    class Program
    {
        static void F1() { Console.WriteLine("F1"); }
        static void F2() { Console.WriteLine("F2"); }
        static void F3() { Console.WriteLine("F3"); }
        static void F4() { Console.WriteLine("F4"); }
        static void F5() { Console.WriteLine("F5"); }
        static void F6() { Console.WriteLine("F6"); }
        static void F7() { Console.WriteLine("F7"); }
        static void F8() { Console.WriteLine("F8"); }
        static void F9() { Console.WriteLine("F9"); }
        static void F10() { Console.WriteLine("F10"); }

        static void Main(string[] args)
        {
            //  Parallel.Invoke - Executes each of the provided actions, possibly in parallel.
            //
            // Parameters:
            //   actions:
            //     An array of Action to execute.
            Parallel.Invoke(F1, F2, F3, F4, F5, F6, F7, F8, F9, F10);
        }
    }
}
