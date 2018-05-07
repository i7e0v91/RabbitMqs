using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Sender : RabbitMqActor
    { 
        public void SendMessage(string message)
        {
            var body = Protocol.FormatBody(message);
            _model.BasicPublish("", Constants.MessageQueue, null, body);
        }
    }
}
