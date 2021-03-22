using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.AppData
{
    [Table("Users")]
    public class DBusers
    {
        [Key]
        public int user_id { get; set; }

        public string firstname { get; set; }

        public string middlename { get; set; }

        public string lastname { get; set; }

        public string email_id { get; set; }

        public string username { get; set; }

        public string phonenumber1 { get; set; }

        public string phonenumber2 { get; set; }

        public string password { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string pincode { get; set; }
        [ForeignKey("DBrole")]
        public int role_id { get; set; }

        public virtual DBrole DBrole { get; set; }
    }
}
