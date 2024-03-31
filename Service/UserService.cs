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

        public bool LogIn(Users user)
        {
            return user is null
                 ? LogInUserInvalid()
                 : LogInUserValidation(user);
            
        }
        public Users SignUp(Users user)
        {
           return this.storeageBroker.SignUpUser(user);
        }
        private bool LogInUserInvalid()
        {
            this.loggingBroker.LogError("Your login or password was entered incorrectly");
            return false;
        }
        private bool LogInUserValidation(Users user)
        {
            if(String.IsNullOrWhiteSpace(user.Name) 
                || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogError("Incoming data is incomplete");
                return false;  
            }
            else
            {
               bool userInfo = this.storeageBroker.CheckoutUser(user);
                if(userInfo is true)
                {
                    this.loggingBroker.LogInformation("successful");
                }
                else
                {
                    this.loggingBroker.LogError("Not found");
                }
                return userInfo;
            }
        }

    }
}
