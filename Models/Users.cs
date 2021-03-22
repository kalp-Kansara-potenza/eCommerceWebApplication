using Ecommerce.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        [Required(ErrorMessage ="Please enter Firstname")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Enter Valid First Name")]
        public string firstname { get; set; }

        public string middlename { get; set; }

        [Required(ErrorMessage = "Please enter Lastname")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid last Name")]
        public string lastname { get; set; }

        
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$", ErrorMessage = "Enter Valid Email Id")]
        public string email_id { get; set; }

        [Required(ErrorMessage = "Please enter Username")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]{6,}$", ErrorMessage = "Enter valid UserName [length upto 6 charecter]")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter Mobile Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter Valid Mobile Number")]
        public string phonenumber1 { get; set; }

        public string phonenumber2 { get; set; }

        //password must have Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character
        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "enter valid password")]
        public string password { get; set; }
        
        [Required(ErrorMessage = "Please enter Address")]
        public string address1 { get; set; }

        public string address2 { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage = "Enter valid city name")]
        public string city { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter valid state name")]
        public string state { get; set; }

        [Required(ErrorMessage = "Please enter pincode")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Enter valid Pincode")]
        public string pincode { get; set; }
        [ForeignKey("DBrole")]
        public int role_id { get; set; }

    }
}
