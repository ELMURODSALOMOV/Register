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

        public Users[] ReadAllUser()
        {
            var userInfo = this.storeageBroker.GetAllUser();
            if (userInfo.Length is 0)
            {
                this.loggingBroker.LogError("Information not available.");
            }
            else
            {
                for (int itaration = 0; itaration < userInfo.Length; itaration++)
                {
                    if (userInfo[itaration] is not null)
                    {
                        this.loggingBroker.LogInformation($"{userInfo[itaration].Name}.{userInfo[itaration].Password}");
                    }
                }
            }
            return userInfo;
        }
    }
}
