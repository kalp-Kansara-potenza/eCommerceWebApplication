using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Models
{
    public class SpecificationType
    {
        public int specificationtype_id { get; set; }

        public int? featuretype_id { get; set; }

        public string specificationtype_name { get; set; }

        public string featuretype_name { get; set; }
    }
}
