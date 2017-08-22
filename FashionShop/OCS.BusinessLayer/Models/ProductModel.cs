using System;
using System.ComponentModel.DataAnnotations;

namespace OCS.BusinessLayer.Models
{
    public class ProductModel
    {
        public Guid ProductID { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Product Name required")]
        [StringLength(50,ErrorMessage ="Product Name is too long!")]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Price is mandatory")]
        [Range(0,9999,ErrorMessage ="Invalid Price Range!")]
        public double ProductPrice { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage ="Brand is mandatory")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Category is mandatory")]
        [StringLength(50)]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add an image.")]
        [StringLength(200)]
        public string Image { get; set; }
        
    }
}
