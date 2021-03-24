using eCommerceWebApplication.API.Repository;
using eCommerceWebApplication.AppData.Context;
using eCommerceWebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceWebApplication.API.APIControllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class APIAccountController : Controller
    {

        /// <summary>
        /// Account controller responsible for perform the registration, login, forgot-password, and send mail for the forgot password
        /// </summary>
        private IConfiguration configuration;
        private IAccount iaccount;
       
        public APIAccountController(IConfiguration _configuration, IAccount _iaccount)
        {
            
            configuration = _configuration;
            iaccount = _iaccount;
        }

        [HttpGet("Registration")]
        public IActionResult Registration()
        {
            return Ok();
        }

        [HttpPost("Registration")]
        public IActionResult Registration(Users users)
        {
            try
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
                        return NotFound("User name or Email-ID is already existed please try another");
                    }
                }
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }


        [HttpGet("Login")]
        
        public IActionResult Login()
        {
            return Ok();
        }
        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        
        public IActionResult Login(Login login)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var userlogin = iaccount.Login(login);
                    if (userlogin == null)
                    {
                        return NotFound("username and password invalid");
                    }
                
                    return Ok("Login Successfull");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpGet("forgotpassword")]
        public IActionResult forgotpassword(string email_id)
        {
            try
            {
                
                Users users = new Users();
                users.email_id = email_id;
                var getuser = iaccount.finduser(users);
                var stringbuilder = iaccount.stringencrypt(getuser.user_id.ToString());

                string subject = "Forgot Password";
                string body = "<br /><br /> Please click the following button to reset password of your account <br /><a href = '" + Url.Action("changepassword", "account", new { user_id = stringbuilder }, Url.ActionContext.HttpContext.Request.Scheme) + "'><button style='background-color:#5a5454;color:white;'>Reset password</button></a>";
                util u = new util(configuration);
                if (getuser != null)
                {
                    u.sendEmail(subject, body, email_id);
                    return Ok();
                }
                else
                {
                    List<string> err = new List<string>();
                    err.Add("Email-id is not register!");
                    return Json(new { success = false, errors = err });
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpGet("changepassword")]
        public IActionResult changepassword(string user_id)
        {
            try
            {
                int uid = Convert.ToInt32(iaccount.stringencrypt(user_id));

                Users user = new Users();
                user.user_id = uid;
                var getuser = iaccount.finduser(user);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpPost("changepassword")]
        public IActionResult changepassword(ChangePasswordModel change)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    iaccount.changepassword(change);
                }
                return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

    }
}
