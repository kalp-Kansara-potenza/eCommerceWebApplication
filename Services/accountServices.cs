using eCommerceWebApplication.Models;
using eCommerceWebApplication.Services.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Services
{
    public class accountServices : IaccountServices
    {
        private IConfiguration configuration { get; }
        public accountServices(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public int stringdcrypt(string str)
        {
            throw new NotImplementedException();
        }

        public string stringencrypt(string str)
        {
            throw new NotImplementedException();
        }

        public Task<Users> Login(Login login)
        {

            throw new NotImplementedException();
        }

        public Task Registration(Users users)
        {
            throw new NotImplementedException();
        }

        public Task<Users> finduser(Users users)
        {
            throw new NotImplementedException();
        }

        public Task changepassword(ChangePasswordModel change)
        {
            throw new NotImplementedException();
        }
    }
}
