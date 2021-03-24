using eCommerceWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Services.Interface
{
    public interface IaccountServices
    {
        int stringdcrypt(string str);
        string stringencrypt(string str);
        Task<Users> Login(Login login);
        Task Registration(Users users);
        Task<Users> finduser(Users users);
        Task changepassword(ChangePasswordModel change);

    }
}
