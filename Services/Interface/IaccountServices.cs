using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interface
{
    public interface IaccountServices
    {
        string stringencrypt(string str);
        Login Login(Login login);
        void Registration(Users users);
        Users finduser(Users users);
        void changepassword(ChangePasswordModel change);

    }
}
