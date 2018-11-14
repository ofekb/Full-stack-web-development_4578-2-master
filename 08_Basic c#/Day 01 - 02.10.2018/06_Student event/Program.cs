using System;

namespace _06_Student_action
{

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            //The event 'Student.MorningActions' can only appear on the left hand side of += or -= 
            //(except when used from within the type 'Student')	
            //student.MorningActions= (string s) => { Console.WriteLine(s); };  //--> COMPILATION ERROR



            //step 3 - subscribe a function to the event
            student.MorningActions += (string s) => { Console.WriteLine($"students says: {s}"); };

            student.WakeUp("Good morning :)");

        }
    }
}


/*
 OUTPUT:
 _________________________

students says: Good morning :)

*/
