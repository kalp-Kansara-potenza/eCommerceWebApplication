using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.AppData
{
    [Table("Product")]
    public class DBproduct
    {
        [Key]
        public int product_id { get; set; }

        public string prodcut_name { get; set; }

        public string thumnail_image { get; set; }

        [ForeignKey("DBcategory")]
        public int category_id { get; set; }

        public virtual DBcategory DBcategory { get; set; }

        public float price { get; set; }

        public int total_quantity { get; set; }

        [ForeignKey("DBusers")]
        public int? user_id { get; set; }

        public virtual DBusers DBusers { get; set; }
    }
}
