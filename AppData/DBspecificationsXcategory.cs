using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.AppData
{
    [Table("specificationsXcategory")]
    public class DBspecificationsXcategory
    {
        [Key]
        public int specificationsXcategory_id { get; set; }

        [ForeignKey("DBcategory")]
        public int category_id { get; set; }
        public virtual DBcategory DBcategory { get; set; }

        [ForeignKey("DBfeaturetype")]
        public int featuretype_id { get; set; }
        public virtual DBfeaturetype DBfeaturetype { get; set; }

        [ForeignKey("DBSpecificationtype")]
        public int specificationtype_id { get; set; }
        public virtual DBspecificationtype DBSpecificationtype { get; set; }
    }
}
