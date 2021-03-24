using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Models
{
    public class Login
    {
        public int user_id { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        
        public string user_name { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        
        public string password { get; set; }

        [Required]
        public bool RememberMe { get; set; }

        public int role_id { get; set; }
        public string role_name { get; set; }
    }
}
