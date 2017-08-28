using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.DTO
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid ShoppingCartItemID { get; set; }

        [Required]
        public ShoppingCart ShoppingCart { get; set; }

        [Required]
        public Product Product { get; set; }

        [Range(1, 999)]
        public int Quantity { get; set; } = 1;
    }
}
