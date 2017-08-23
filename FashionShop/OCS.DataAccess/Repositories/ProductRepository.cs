using System;
using System.Collections.Generic;
using System.Linq;

namespace OCS.DataAccess.Repositories
{

    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (DataModel db = new DataModel())
            {
                var products = db.Products.Include("Category")
                                          .Include("Brand")
                                          .Select(x => x).ToList();
                return products;
            }
        }

        public Product GetProductById(Guid id)
        {
            using (DataModel db = new DataModel())
            {
                var prod = db.Products.Include("Category")
                                      .Include("Brand")
                                      .FirstOrDefault(x => x.ProductID == id);
                return prod;
            }
        }

        public void SaveProduct(Product product)
        {
            using (DataModel db = new DataModel())
            {
                db.Products.Add(product);
                var sc = db.SaveChanges();
            }
        }
    }
}
