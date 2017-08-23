using System;
using System.ComponentModel.DataAnnotations;

namespace OCS.BusinessLayer.Models
{
    public class ProductModel
    {
        public Guid ProductID { get; set; }

        [Required(AllowEmptyStrings =false)]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(0,9999)]
        public double ProductPrice { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(200)]
        public string Image { get; set; }
        
    }
}
