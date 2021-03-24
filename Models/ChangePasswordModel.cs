using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Models
{
    public class ChangePasswordModel
    {
        public int user_id { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "enter valid password")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string confirmpassword { get; set; }
    }
}
