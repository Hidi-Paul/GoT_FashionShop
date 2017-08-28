using OCS.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Services
{
    public interface IShoppingCartServices
    {
        ShoppingCartModel GetShoppingCartByUser(string user);
        void AddProduct(ShoppingCartItemModel model, string user);
    }
}
