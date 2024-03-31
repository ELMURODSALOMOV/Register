using Register.Broker.Logging;
using Register.Broker.Storeage;
using Register.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
           return this.storeageBroker.CheckoutUser(user);
        }

        public Users SignUp(Users user)
        {
           return user is null
                ? SignUpUsersInvalid()
                : ValidationAndSignUpUser(user);
        }

        private Users ValidationAndSignUpUser(Users user)
        {
            if(String.IsNullOrWhiteSpace(user.Name)
              || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogError("Invalid user information.");
                return new Users();
            }
            else
            {
                var userInformation = this.storeageBroker.SignUpUser(user);
                if(userInformation is null)
                {
                    this.loggingBroker.LogError("Not added user info");
                }
                else
                {
                    this.loggingBroker.LogInformation("Added user");
                }
                return userInformation;
            }
        }

        private Users SignUpUsersInvalid()
        {
            this.loggingBroker.LogError("User information is null.");
            return new Users();
        }
    }
}
