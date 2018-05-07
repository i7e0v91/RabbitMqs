using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Receiver : RabbitMqActor, IBasicConsumer
    {
        public event Action<object, string, string> OnMessageReceivedEvent;
        public event EventHandler<ConsumerEventArgs> ConsumerCancelled;

        private string _queueName;


        public Receiver(string queueName) : base()
        {
            _queueName = queueName;
            StartConsume();
        }

        private void StartConsume()
        {
            _model.BasicConsume(_queueName, false, Guid.NewGuid().ToString(), true, false, null, this);
        }

        private void FireMessageReceived(string routingKey, string message)
        {
            if (OnMessageReceivedEvent != null)
                OnMessageReceivedEvent(this, routingKey, message);
        }

        #region IBasicConsumer 

        public IModel Model
        {
            get
            {
                return _model;
            }
        }

        public void HandleBasicCancel(string consumerTag)
        {
            //
        }

        public void HandleBasicCancelOk(string consumerTag)
        {
            //
        }

        public void HandleBasicConsumeOk(string consumerTag)
        {
            //
        }

        public void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            var message = Protocol.ParseBody(body);
            FireMessageReceived(routingKey, message);
        }

        public void HandleModelShutdown(object model, ShutdownEventArgs reason)
        {
            //
        }

        #endregion
    }
}
