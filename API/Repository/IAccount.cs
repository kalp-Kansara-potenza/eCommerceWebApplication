using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Repository
{
    public interface IAccount
    {
        string stringencrypt(string str);
        Login Login(Login login);
        void Registration(Users users);
        Users finduser(Users users);
        void changepassword(ChangePasswordModel change);

    }
}
