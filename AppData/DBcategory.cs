using eCommerceWebApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.AppData
{
    [Table("Category")]
    public class DBcategory
    {
        
        [Key]
        public int category_id { get; set; }

        public string category_name { get; set; }

        public string thumbnail_image { get; set; }

        public int? parent_category_id { get; set; }
    }
}
