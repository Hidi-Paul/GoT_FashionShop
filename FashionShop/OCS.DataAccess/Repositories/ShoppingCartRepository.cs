using OCS.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public ShoppingCart GetByUser(string user)
        {
            using(DataModel db = new DataModel())
            {
                var shoppingCart = db.ShoppingCarts
                                            .Include("ShoppingCartItems")
                                            .Include("ShoppingCartItems.Product")
                                            .FirstOrDefault(x => x.AppUserEmail.Equals(user));
                return shoppingCart;
            }
        }
        public void AddCart(ShoppingCart cart)
        {
            using(DataModel db=new DataModel())
            {
                db.ShoppingCarts.Add(cart);
            }
        }

        public Task<int> SaveChangesAsync()
        {
            using (DataModel db = new DataModel())
            {
                return db.SaveChangesAsync();
            }
        }
    }
}
