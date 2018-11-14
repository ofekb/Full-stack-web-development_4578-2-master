using System;
using System.Threading;

namespace _07_WaitHandleObject
{

    class Email
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Email(string email, string subject, string body)
        {
            EmailAddress = email;
            Subject = subject;
            Body = body;
        }

        public void Send()
        {
            Console.WriteLine($"Sending email to: {EmailAddress}, subject: {Subject}, body: {Body}");
        }
    }

    class Program
    {
        static Random rnd = new Random();
        static AutoResetEvent areManagerEmail = new AutoResetEvent(false);
        static AutoResetEvent areSalesManEmail = new AutoResetEvent(false);
        static AutoResetEvent areSupplierEmail = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            AutoResetEvent[] autoResetEvents = {
                areManagerEmail,
                areSalesManEmail,
                areSupplierEmail
            };

            Thread t1 = new Thread(SendEmailToManager);
            t1.Start();
            Thread t2 = new Thread(SendEmailToSalesMan);
            t2.Start();
            Thread t3 = new Thread(SendEmailToSupplier);
            t3.Start();

            //WaitHandle.WaitAll(autoResetEvents);
            WaitHandle.WaitAny(autoResetEvents);
            Console.WriteLine("Done.");
        }
        static void SendEmailToManager()
        {
            Email email = new Email("Dan@comp.com", "hi", "some message...");
            Thread.Sleep(rnd.Next(1000, 2000));
            email.Send();
            areManagerEmail.Set();
        }
        static void SendEmailToSalesMan()
        {
            Email email = new Email("haim@comp.com", "hi", "some message...");
            Thread.Sleep(rnd.Next(3000, 6000));
            email.Send();
            areSalesManEmail.Set();
        }
        static void SendEmailToSupplier()
        {
            Email email = new Email("eli@comp.com", "hi", "some message...");
            Thread.Sleep(rnd.Next(2000, 5000));
            email.Send();
            areSupplierEmail.Set();
        }
    }
}
