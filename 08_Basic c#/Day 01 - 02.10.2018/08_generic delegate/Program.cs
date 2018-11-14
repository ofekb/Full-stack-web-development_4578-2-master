using System;

namespace Action_Func_and_Predicate
{
    class Program
    {
        static void Main(string[] args)
        {

            //-------------------Predicate-------------------

            //Predicate - gets one parameter
            //the type of the parameter is in the <>
            //returns a boolean val

            Predicate<int> pr1 = x => x == x;


            //-------------------Action-------------------


            //יש להעביר פרמטרים מופרדים בפסיק -  16- 1 פרמטרים
            //the type of the parameter is in the <>
            //אבל אי אפשר בשום מצב להחזיר ערך



            //a delegate that can ref any function that gets int and returns void
            Action<int> a1 = PrintNum;


            Action<int> a2 = (int x) => {
                Console.WriteLine($"in PrintNum {x}");
            };

            Action<int> a3 = x => Console.WriteLine($"in PrintNum {x}");


            //if we have more than one command in the body of the action
            //we must use {}
            Action<int> a4 = x => {
                int z = x + 1;
                Console.WriteLine($"in PrintNum {z}");
            };


            Action<int, int> a5 = (i, j) => { Console.WriteLine($"{i}{j}"); };

            //------------------------------Func-----------------------------
            //Func -  no parameters and returns a value of the type
            //specified by the <>


            //יש להעביר פרמטרים מופרדים בפסיק -  17 - 1 פרמטרים
            //the type of the parameter is in the <>
            //הפרמטר האחרון מהרשימה הוא זה שיקבע את סוג הערך המוחזר
            //כל השאר קובעים פרמטרים שהפונקציה מקבלת


            //פונקציה שלא מקבלת פרמטרים ומחזירה מספר
            Func<int> f1 = () => { return 6; };  //דרך ראשונה

            //פונקציה שלא מקבלת פרמטרים ומחזירה מספר
            //will understand that 6 is the returned val
            Func<int> f2 = () => 6;  //דרך שניה - זהה לראשונה

            //פונקציה שלא מקבלת פרמטרים ומחזירה מספר
            //if we have more than one command in the body of the action
            //we must use {} and return
            Func<int> f3 = () => {
                int a = 6;
                a *= 9;
                return a;
            };



            //פונקציה שמקבלת שלושה מספרים ומחזירה את הממוצע שלהם
            //will understand that 6 is the returned val
            Func<int, int, int, int> f4 = (n1, n2, n3) => {
                int i = n1 + n2 + n3;
                return i / 3;
            };


            Func<int, int, int, int> f5 = (n1, n2, n3) => (n1 + n2 + n3) / 3;

        }


        static void PrintNum(int i)
        {
            Console.WriteLine($"in PrintNum {i}");
        }
    }
}

