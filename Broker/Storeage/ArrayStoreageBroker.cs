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
                Name = "Elmurod",
                Password = "password",
            };
            UsersInfo[1] = new Users()
            {
                Name = "Asilbek",
                Password = "Asilbek11",
            };
        }
        public Users ReadUser(string name, string password)
        {
            for (int itaration = 0; itaration < UsersInfo.Length; itaration++)
            {
                Users UsersInfoLine = UsersInfo[itaration];
                if (UsersInfoLine.Name == name)
                {
                    return UsersInfoLine;
                }
            }
            return new Users();
        }
    }
}
