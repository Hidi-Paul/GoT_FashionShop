using System;
namespace OCS.BusinessLayer.Models
{
    public class ProductModel
    {
        public Guid ProductID { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string Gender { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }
        
    }
}
