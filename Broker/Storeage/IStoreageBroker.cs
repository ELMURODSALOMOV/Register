using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Broker.Storeage
{
    internal interface IStoreageBroker
    {
        Users ReadUser(string name, string password);
        Users[] GetAllUser();
    }
}
