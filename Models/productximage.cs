using eCommerceWebApplication.AppData;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Models
{
    public class productximage
    {
        
        public int productximage_id { get; set; }

        [DataType(DataType.Upload)]
        [MaxLength(1024, ErrorMessage = "upload photo < 1024 kbs")]
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "please enter valid formet like jpg, png or jpeg ")]
        public string product_images { get; set; }

        
        public int product_id { get; set; }

        public List<IFormFile> multiplefile { get; set; }

        public IFormFile file { get; set; }

    }
}
