namespace OCS.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Categories = new HashSet<Category>();
        }

        public Guid ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public double? ProductPrice { get; set; }

        public Guid? GenderID { get; set; }

        public Guid? ColorID { get; set; }

        public Guid? BrandID { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        public virtual Color Color { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
