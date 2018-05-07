using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public abstract class RabbitMqActor : IDisposable
    {

        protected IConnection _connection;
        protected IModel _model;

        public RabbitMqActor()
        {
            SetUp();
        }

        public void Dispose()
        {
            _model.Close();
            if (_model != null)
                _model.Dispose();

            if (_connection != null)
                _connection.Dispose();
        }

        private void SetUp()
        {
            // connection
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";
            factory.VirtualHost = "/";
            _connection = factory.CreateConnection();

            // channel
            _model = _connection.CreateModel();
        }
    }
}
