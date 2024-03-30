using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Broker
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string UserMessage);
    }
}
