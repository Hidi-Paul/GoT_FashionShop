using System;
using System.Collections.Generic;

namespace OCS.DataAccess.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(Guid id);

        void SaveProduct(Product product);
    }
}