using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.DTO
{
    public class ShoppingCart
    {
        [Key]
        public Guid ShoppingCartID { get; set; }

        [Required]
        public string AppUserEmail { get; set; }

        public virtual IList<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
