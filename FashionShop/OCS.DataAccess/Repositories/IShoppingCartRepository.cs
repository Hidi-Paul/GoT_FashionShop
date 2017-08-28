using OCS.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetByUser(string user);
        void AddCart(ShoppingCart cart);
        Task<int> SaveChangesAsync();
    }
}
