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
        bool LogIn(Users user);
        Users SignUp(Users user);
    }
}
