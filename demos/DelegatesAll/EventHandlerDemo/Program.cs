using System;


namespace EventHandlerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandlerClass eventHandlerClass = new EventHandlerClass();
            MethodsClass methodsClass = new MethodsClass();

            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend1; //can only subscribe methods to the event with += and remove with -=
            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend2;

            Console.WriteLine("Enter a word:");
            string message = Console.ReadLine();
            eventHandlerClass.MessageSend(message);
        }
    }
}
