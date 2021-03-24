using eCommerceWebApplication.AppData;
using eCommerceWebApplication.AppData.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }

        [Required(ErrorMessage = "Product Name is compulsory")]
        [RegularExpression(@"^[a-zA-Z0-9,& ]+$", ErrorMessage = "Enter valid Product Name")]
        public string prodcut_name { get; set; }

        [Required(ErrorMessage = "Please Select File")]
        [DataType(DataType.Upload)]
        [MaxLength(1024, ErrorMessage = "upload photo < 1024 kbs")]
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "please enter valid formet like jpg, png or jpeg ")]
        public string thumnail_image { get; set; }

        [ForeignKey("DBcategory")]
        public int category_id { get; set; }

        public virtual DBcategory DBcategory { get; set; }

        [Required(ErrorMessage = "Product Proce is compulsory")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Enter valid Product price")]
        public float price { get; set; }

        [Required(ErrorMessage = "Total quantity is compulsory")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Enter valid Total quantity")]
        public int total_quantity { get; set; }

        [ForeignKey("DBuser")]
        public int? user_id { get; set; }

        public virtual DBusers DBusers { get; set; }

        public IFormFile file { get; set; }

        public string category_name { get; set; }

        public int productximage_id { get; set; }

        [DataType(DataType.Upload)]
        [MaxLength(1024, ErrorMessage = "upload photo < 1024 kbs")]
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "please enter valid formet like jpg, png or jpeg ")]
        public string product_images { get; set; }


        public List<IFormFile> multiplefile { get; set; }

        public List<DBproductximage> multiplefiles { get; set; }

        public int specification_id { get; set; }

        public int specificationtype_id { get; set; }
        public string specificationtype_name { get; set; }

        public int featuretype_id { get; set; }
        public string featuretype_name { get; set; }

        public string specification_description { get; set; }

        public List<DBspecification> specifications { get; set; }

        public List<Specification> specificationslist { get; set; }

        public string stringdata { get; set; }
    }
}
