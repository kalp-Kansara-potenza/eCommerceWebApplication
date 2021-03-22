using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.AppData.Context
{
    [Table("Specification")]
    public class DBspecification
    {
        [Key]
        public int specification_id { get; set; }

        [ForeignKey("DBspecificationtype")]
        public int specificationtype_id { get; set; }
        public virtual DBspecificationtype DBspecificationtype { get; set; }

        [ForeignKey("DBproduct")]
        public int product_id { get; set; }
        public virtual DBproduct DBproduct { get; set; }

        [ForeignKey("DBfeaturetype")]
        public int featuretype_id { get; set; }
        public virtual DBfeaturetype DBfeaturetype { get; set; }

        public string specification_description { get; set; }
    }
}
