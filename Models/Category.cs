using eCommerceWebApplication.AppData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Models
{
    public class Category
    {
        public int category_id { get; set; }

        [Required(ErrorMessage = "Category Name is compulsory")]
        [RegularExpression(@"^[a-zA-Z,& ]+$", ErrorMessage = "Enter valid Category Name")]
        
        public string category_name { get; set; }

        [Required(ErrorMessage = "Please Select File")]
        [DataType(DataType.Upload)]
        [MaxLength(1024,ErrorMessage = "upload photo < 1024 kbs")]
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "please enter valid formet like jpg, png or jpeg ")]
        public string thumbnail_image { get; set; }

        public IFormFile file { get; set; }

        
        public int? parent_category_id { get; set; }

        public List<Category> categories { get; set; }

        public List<DBspecificationsXcategory> featuretypelist { get; set; }

        public List<DBspecificationsXcategory> specificationtypelist { get; set; }

        public string stringdata { get; set; }

        public List<SpecificationxCategory> specificationxCategories { get; set; }

        
    }
}
