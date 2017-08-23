namespace OCS.DataAccess
{
    using OCS.DataAccess.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [Range(0,9999)]
        public double ProductPrice { get; set; }
        
        public Gender Gender { get; set; }

        public Guid? BrandID { get; set; }

        public Guid? CategoryID { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
