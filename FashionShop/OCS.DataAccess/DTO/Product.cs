namespace OCS.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Gender
    {
        Male, Female, Unisex
    }

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {

        }
        
        [Key]
        public Guid ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public double? ProductPrice { get; set; }
        
        public Gender Gender { get; set; }

        public Guid? BrandID { get; set; }

        public Guid? CategoryID { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        public string Image { get; set; }
    }
}
