namespace OCS.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public class Brand
    {
        [Key]
        public Guid BrandID { get; set; }

        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
