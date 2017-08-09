using System;
using System.Collections.Generic;

namespace OCS.DataAccess.Repositories
{
    internal interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(Guid id);

        void AddProduct(Product product);
    }
}