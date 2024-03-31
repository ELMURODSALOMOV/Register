using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Service
{
    internal interface IUserService
    {
        Users GetUser(string username, string password);
        Users[] ReadAllUser();
    }
}
