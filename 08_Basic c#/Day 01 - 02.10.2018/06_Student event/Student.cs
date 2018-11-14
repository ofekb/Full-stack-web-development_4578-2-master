namespace _06_Student_action
{
   //step 1 - declare a delegate
   delegate void ActionHandler(string subject);


    class Student
    {   
        //step 2 - create an event with the delegate from step 1
        public event ActionHandler MorningActions;

       
        public void WakeUp(string str)
        {
            //step 4 - raise the event
            MorningActions(str);
        }
    }
}
