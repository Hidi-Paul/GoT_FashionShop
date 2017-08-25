using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.MVC.Models
{
    public class CreateProductViewModel
    {
        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name required.")]
        [StringLength(50, ErrorMessage = "Product Name is too long!")]
        public string ProductName { get; set; }

        [DisplayName("Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is mandatory.")]
        [Range(1, 9999, ErrorMessage = "Invalid Price Range!")]
        public double ProductPrice { get; set; }

        [DisplayName("Brand")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Brand is mandatory.")]
        [StringLength(50, ErrorMessage = "Brand too long.")]
        public string Brand { get; set; }

        [DisplayName("Category")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category is mandatory.")]
        [StringLength(50)]
        public string Category { get; set; }

        [DisplayName("Image")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add an image.")]
        [StringLength(200)]
        public string Image { get; set; }
    }
}