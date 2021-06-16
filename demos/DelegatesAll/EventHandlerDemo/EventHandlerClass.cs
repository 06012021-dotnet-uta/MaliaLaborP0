using System;

namespace EventHandlerDemo
{
    public class EventHandlerClass
    {
        //create the delegate type
        public delegate void MessageHandler(object source, MessageEventArgsClass args);

        //instantiate delegate
        public event MessageHandler myMessageHandler;

        //raise the event (or invoke the event) through this preparatory/protector method
        public void MessageSend(string message)
        {
            //message += message;
            OnMessageSend(message);
        }

        private void OnMessageSend(string msg)
        {
            //check if there are any subscribers to the delegate
            if (myMessageHandler != null)
            {
                MessageEventArgsClass meac = new MessageEventArgsClass() {MyString = msg};
                myMessageHandler(this, meac);
                Console.WriteLine(meac.MyString);
            }
        }
    }
}