using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            var receiver_messages = new Receiver(Constants.MessageQueue);
            var receiver_logs = new Receiver(Constants.LogQueue);

            receiver_logs.OnMessageReceivedEvent += Receiver_logs_OnMessageReceivedEvent;
            receiver_messages.OnMessageReceivedEvent += Receiver_messages_OnMessageReceivedEvent;

            var counter = 0;

            Console.WriteLine("Begin pressing char keys to generate messages!");
            while (true)
            {
                Console.ReadKey(true);

                var newMessage = string.Format("TestMessage_{0}", ++counter);
                Console.WriteLine("Sending message: " + newMessage);
                sender.SendMessage(newMessage);
            }
        }

        private static void Receiver_messages_OnMessageReceivedEvent(object arg1, string routingKey, string message)
        {
            Console.WriteLine("GOT MSG: [{0}]", message);
        }

        private static void Receiver_logs_OnMessageReceivedEvent(object arg1, string routingKey, string message)
        {
            Console.WriteLine("GOT LOG: [{0}] ({1})", message, routingKey);
        }
    }
}
