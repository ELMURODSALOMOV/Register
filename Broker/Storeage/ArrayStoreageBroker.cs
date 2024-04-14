using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Register.Broker.Storeage
{
    internal class ArrayStoreageBroker : IStoreageBroker
    {
        private Users[] UsersInfo { get; set; } = new Users[10];
        public ArrayStoreageBroker()
        {
            UsersInfo[0] = new Users()
            {
                Email = "Elmurod@gmail.com",
                Password = "password",
            };
            UsersInfo[1] = new Users()
            {
                Email = "Asilbek@gmail.com",
                Password = "Asilbek11",
            };
        }
        public Users SignUpUser(Users user)
        {
            for(int iteration = 0; iteration < UsersInfo.Length; iteration++)
            {
                if (UsersInfo[iteration] is null)
                {
                    var UserInfo = new Users()
                    {
                        Email = user.Email,
                        Password = user.Password
                    };
                    UsersInfo[iteration] = UserInfo;
                    return user;
                }
            }
            return new Users();
        }
        public bool CheckoutUser(Users user)
        {
            for(int itaration = 0;itaration < UsersInfo.Length;itaration++)
            {
                var userInformation = UsersInfo[itaration];
                if(userInformation is not null)
                {
                    if(userInformation.Email == user.Email && userInformation.Password == user.Password)
                    {
                       return true;
                    }
                }
            }
            return false;
        }
    }
}
