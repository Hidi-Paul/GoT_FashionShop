using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OCS.MVC.Models
{
    public class ProductViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name required.")]
        [StringLength(50, ErrorMessage = "Product Name is too long!")]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is mandatory.")]
        [Range(0, 9999, ErrorMessage = "Invalid Price Range!")]
        public double ProductPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Brand is mandatory.")]
        [StringLength(50, ErrorMessage = "Brand too long.")]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add an image.")]
        [StringLength(200)]
        public string Image { get; set; }

    }
}