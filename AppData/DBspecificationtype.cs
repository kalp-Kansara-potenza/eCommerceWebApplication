using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.AppData
{
    [Table("SpecificationType")]
    public class DBspecificationtype
    {
        [Key]
        public int specificationtype_Id { get; set; }

        [ForeignKey("DBfeaturetype")]
        public int? featuretype_id { get; set; }
        public virtual DBfeaturetype DBfeaturetype { get; set; }

        public string specificationtype_name { get; set; }
    }
}
