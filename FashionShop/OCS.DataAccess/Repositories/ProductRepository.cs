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
                var products = db.Products.Select(x => x).ToList();
                return products;
            }
        }

        public Product GetProductById(Guid id)
        {
            using (DataModel db = new DataModel())
            {
                Product myProduct = new Product();
                var products = db.Products.Select(x => x).ToList();
                myProduct = products.Where(x => x.ProductID == id).FirstOrDefault();
                return myProduct;
            }
        }

        public void SaveProduct(Product product)
        {
            using (DataModel db = new DataModel())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }
}
