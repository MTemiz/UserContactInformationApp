using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Constants
{
    public enum EventBusType
    {
        RabbitMQ = 1,
        ActiveMQ = 2,
        KafkaMQ = 3,
        AzureMQ = 4
    }
}
