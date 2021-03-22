using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.AppData
{
    [Table("FeatureType")]
    public class DBfeaturetype
    {
        [Key]
        public int featuretype_id { get; set; }

        public string featuretype_name { get; set; }
    }
}
