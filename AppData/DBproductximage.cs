using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.AppData
{
    [Table("productXimage")]
    public class DBproductximage
    {
        [Key]
        public int productximage_id { get; set; }

        public string product_images { get; set; }

        [ForeignKey("DBproduct")]
        public int product_id { get; set; }

        public virtual DBproduct DBproduct { get; set; }
    }
}
