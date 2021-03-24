using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Models
{
    public class Specification
    {
        public int specification_id { get; set; }

        public int specificationtype_id { get; set; }
        public string specificationtype_name { get; set; }

        public int product_id { get; set; }
        public string product_name { get; set; }

        public int featuretype_id { get; set; }
        public string featuretype_name { get; set; }

        public string specification_description { get; set; }

    }
}
