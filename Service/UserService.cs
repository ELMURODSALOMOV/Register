using Register.Broker.Logging;
using Register.Broker.Storeage;
using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Register.Service
{
    internal class UserService : IUserService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IStoreageBroker storeageBroker;
        public UserService()
        {
            this.loggingBroker = new LoggingBroker();
            this.storeageBroker = new ArrayStoreageBroker();
        }
        public Users GetUser(string name, string password)
        {
            Users user = this.storeageBroker.ReadUser(name, password);
            return user;
        }
    }
}
