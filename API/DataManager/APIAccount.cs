using Ecommerce.API.Repository;
using Ecommerce.AppData;
using Ecommerce.AppData.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.API.DataManager
{
    public class APIAccount : IAccount
    {
        private ecommerceContext ecomContext;
        private const string SecurityKey = "ecommerce_01022020";

        public APIAccount(ecommerceContext ecomContext)
        {
            this.ecomContext = ecomContext;
        }

        public string stringencrypt(string str)
        {
            try
            {
                MD5CryptoServiceProvider mD5CryptoService = new MD5CryptoServiceProvider();
                byte[] utf8str = UTF8Encoding.UTF8.GetBytes(str);
                byte[] securityKeyArray = mD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));

                mD5CryptoService.Clear();
                var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
                objTripleDESCryptoService.Key = securityKeyArray;
                objTripleDESCryptoService.Mode = CipherMode.ECB;
                objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

                var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
                byte[] resultArray = objCrytpoTransform.TransformFinalBlock(utf8str, 0, utf8str.Length);
                objTripleDESCryptoService.Clear();

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            throw new NotImplementedException();
        }

        public Login Login(Login login)
        {
            var pass = stringencrypt(login.password);
            var user = ecomContext.Set<DBusers>().ToList().Where(u => (u.username == login.user_name || u.email_id == login.user_name ) && u.password == pass).Select(u => new Login
            { 
                user_id = u.user_id,
                user_name = u.username,
                password = u.password,
                RememberMe = false,
                role_id = u.role_id
            }).FirstOrDefault();
            
            if (user == null)
            {
                return null;
            }
            var role = ecomContext.Set<DBrole>().ToList().Where(r => r.role_id == user.role_id).FirstOrDefault();
            user.role_name = role.role_name;
            return user;
            
        }

        public Users finduser(Users users)
        {
            var userdata = ecomContext.DBusers.Where(user => user.username == users.username || user.email_id == users.email_id || user.user_id == users.user_id).Select(u=>new Users{ 
                user_id = users.user_id,
                username = users.username,
                firstname = users.firstname,
                middlename = users.middlename,
                lastname = users.lastname,
                email_id = users.email_id,
                phonenumber1 = users.phonenumber1,
                phonenumber2 = users.phonenumber2,
                password = users.password,
                address1 = users.address1,
                address2 = users.address2,
                city = users.city,
                state = users.state,
                pincode = users.pincode,
                role_id = users.role_id
            }).FirstOrDefault();
            return userdata;
        }

        public void Registration(Users users)
        {
            var userdata = finduser(users);
            if(userdata == null)
            {
                DBusers user = new DBusers();
                user.firstname = users.firstname;
                user.middlename = users.middlename;
                user.lastname = users.lastname;
                user.username = users.username;
                user.email_id = users.email_id;
                user.phonenumber1 = users.phonenumber1;
                user.phonenumber2 = users.phonenumber2;
                user.password = stringencrypt(users.password);
                user.address1 = users.address1;
                user.address2 = users.address2;
                user.city = users.city;
                user.state = users.state;
                user.pincode = users.pincode;
                user.role_id = 2;

                ecomContext.Add(user);
                ecomContext.SaveChanges();
            }
        }
        
        public void changepassword(ChangePasswordModel change)
        {
            Users users = new Users();
            users.user_id = change.user_id;
            var getuser = finduser(users);
            if(getuser != null)
            {
                getuser.password = stringencrypt(change.password);
                ecomContext.SaveChanges();
            }
        }
    }
}
