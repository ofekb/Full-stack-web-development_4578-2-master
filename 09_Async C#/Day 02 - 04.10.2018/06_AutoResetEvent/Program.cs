using System;
using System.Threading;

namespace _06_AutoResetEvent
{

    class ShapesDrawer
    {
        // AutoResetEvent - Notifies a waiting thread that an event has occurred. 
        private AutoResetEvent autoResetEvent = new AutoResetEvent(true); // Must be true so the first thread could not be blocked and could pass the WaitOne command.

        public void Draw()
        {
            Thread tRectangle = new Thread(DrawRectangle);
            tRectangle.Start();
            Thread tTriangle = new Thread(DrawTriangle);
            tTriangle.Start();
            Thread tLine = new Thread(DrawLine);
            tLine.Start();
        }

        private void DrawRectangle()
        {
            autoResetEvent.WaitOne();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  *****");
            Console.WriteLine("  *****");
            Console.WriteLine("  *****");
            Console.ResetColor();
            autoResetEvent.Set();
        }

        private void DrawTriangle()
        {
            autoResetEvent.WaitOne();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        *");
            Console.WriteLine("       ***");
            Console.WriteLine("      *****");
            Console.WriteLine("     *******");
            Console.ResetColor();
            autoResetEvent.Set();
        }

        private void DrawLine()
        {
            autoResetEvent.WaitOne();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" *");
            Console.WriteLine("  *");
            Console.WriteLine("   *");
            Console.WriteLine("    *");
            Console.ResetColor();
            autoResetEvent.Set();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ShapesDrawer shapeDrawer = new ShapesDrawer();
            shapeDrawer.Draw();
        }
    }
}
