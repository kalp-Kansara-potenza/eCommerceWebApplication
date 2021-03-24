using eCommerceWebApplication.API.Repository;
using eCommerceWebApplication.AppData;
using eCommerceWebApplication.AppData.Context;
using eCommerceWebApplication.Models;
using eCommerceWebApplication.Models.Global;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eCommerceWebApplication.Controllers
{
    public class accountController : Controller
    {
        private ecommerceContext ecomContext;
        private IConfiguration configuration;
        private IAccount iaccount;
        private const string SecurityKey = "ecommerce_01022020";
        public accountController(ecommerceContext ecomContext,IConfiguration _configuration,IAccount _iaccount)
        {
            this.ecomContext = ecomContext;
            configuration = _configuration;
            iaccount = _iaccount;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        public IActionResult Registration(Users users)
        {
            if (ModelState.IsValid)
            {
                var u = iaccount.finduser(users);
                if (u == null)
                {
                    iaccount.Registration(users);
                }
                else
                {
                    ViewBag.err = "User name or Email-ID is already existed please try another";
                    return View();
                }
                return View("Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        
        [HttpPost]
        public IActionResult Login(Login login)
         {
            if (ModelState.IsValid)
            {
                var userlogin = iaccount.Login(login);
                if(userlogin != null)
                { 
                    HttpContext.Session.SetString("username",userlogin.user_name);
                    HttpContext.Session.SetString("rolename", userlogin.role_name);
                }

                if (userlogin == null)
                {
                    ViewBag.err = "username and password invalid";
                    return View(login);
                }
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, login.user_name));
                claims.Add(new Claim(ClaimTypes.Sid, userlogin.user_id.ToString()));
                
                claims.Add(new Claim(ClaimTypes.Role, userlogin.role_name));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaims(new[] {
                    new Claim("rolename",userlogin.role_name),
                    new Claim("username",login.user_name)
                });
                var claim = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
                var principle = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                props.IsPersistent = login.RememberMe;
                if (props.IsPersistent == true)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    HttpContext.Response.Cookies.Append("username", login.user_name);
                    HttpContext.Response.Cookies.Append("password", login.password);
                    cookieOptions.Expires = DateTime.Now.AddDays(1);
                }
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle, props).Wait();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]   
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "account");
        }

        [HttpGet]
        public IActionResult unauthorized()
        {
            return View("unauthorized");
        }

        [HttpGet]
        public IActionResult forgetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult forgotpassword(string email_id)
        {
            ViewBag.mail = email_id;
            Users users = new Users();
            users.email_id = email_id;
            var getuser = iaccount.finduser(users);
            var stringbuilder = iaccount.stringencrypt(getuser.user_id.ToString());
            
            string subject = "Forgot Password";
            string val = "<br /><br /> Please click the following button to reset password of your account <br /><a href = '"+Url.Action("changepassword","account",new { user_id = stringbuilder }, Url.ActionContext.HttpContext.Request.Scheme) + "'><button style='background-color:#5a5454;color:white;'>Reset password</button></a>";
            var body = System.Net.WebUtility.UrlDecode(val);
            var val2 = val.Split('=')[2];
            util u = new util(configuration);
            if(getuser != null)
            {
                u.sendEmail(subject, body, email_id);
                return View();
            }
            else
            {
                List<string> err = new List<string>();
                err.Add("Email-id is not register!");
                return Json(new { success = false, errors = err });
            } 
        }

        [HttpGet]
        public IActionResult changepassword(string user_id)
        {
            int uid = Convert.ToInt32 (iaccount.stringdcrypt(user_id));
            ViewBag.uid = uid;

            Users user = new Users();
            user.user_id = uid;
            var getuser = iaccount.finduser(user);
            return View();
        }

        [HttpPost]
        public IActionResult changepassword(ChangePasswordModel change)
        {
            if (ModelState.IsValid)
            {
                iaccount.changepassword(change);
                return RedirectToAction("Login", "account");
            }
            var temp = String.Equals(change.password, change.confirmpassword);
            if(temp == false)
                ViewBag.err = "Enter same password in confirmpassword";
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
            return View();

        }

        [HttpGet]
        public IActionResult RedirectToLogin()
        {
            return View();
        }
    }
}
