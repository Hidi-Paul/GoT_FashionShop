using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Models
{
    public class ShoppingCartModel
    {
        public IEnumerable<ShoppingCartItemModel> ShoppingCartItems { get; set; }
    }
}
