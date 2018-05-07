using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public static class Constants
    {
        public const string MessageQueue = "Message_All";
        public const string LogQueue = "Log_All";

        public const string LogExchange = "amq.rabbitmq.trace";
    }
}
