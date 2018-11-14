using System;

namespace _06_Student_action
{

    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();

            Console.WriteLine("------------------- student1.WakeUp---------------------");
            student1.WakeUp("Good morning :)");


            Student student2 = new Student();

            student2.MorningActions += (string s) => {
                Console.WriteLine($"I am student2, and my msg is: {s}");
            };

            Console.WriteLine("------------------- student2.WakeUp---------------------");
            student2.WakeUp("Perfect morning :)");

        }
    }
}


/*
 OUTPUT:
 _________________________

------------------- student1.WakeUp---------------------
Sorry - we cant do this event

------------------- student2.WakeUp---------------------
I am student2, and my msg is: Perfect morning :)
I am student2, and my msg is: Perfect morning :)

*/
